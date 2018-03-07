using OA.DepartmentsDto;
using OA.PermissionsDto;
using OA.RolesDto;
using OA.UserDto;
using OA.Web.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Areas.Admin.Controllers
{
    [Skip]
    public class UserController : AdminBaseController
    {
        private readonly IUserInfoAppService _userAppService;
        private readonly IDepartmentAppService _appService;
        private readonly IRoleAppService _roleService;
        private readonly IPermissionAppService _perService;
        public UserController(IUserInfoAppService userAppService, IDepartmentAppService appService, IRoleAppService roleService, IPermissionAppService perService)
        {
            _userAppService = userAppService;
            _appService = appService;
            _roleService = roleService;
            _perService = perService;
        }


        // GET: Admin/User
        public ActionResult Index()
        {
            ViewData["list"] = _userAppService.GetList(0);
            return View();
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            var back = _appService.GetListTree();
            ViewData["depList"] = back;
            return PartialView();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(UserInfoDto model)
        {
            //UserInfoDto  FormCollection
            try
            {
                _userAppService.Insert(model);
                // TODO: Add insert logic here

                AjaxModel.Statu = "ok";

            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();
            }
            return Json(AjaxModel);

            //return Content("ok");
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            var back = _appService.GetListTree();
            ViewData["depList"] = back;
            var model = _userAppService.GetList(id).FirstOrDefault();
            return PartialView("Create", model);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserInfoDto model)
        {
            try
            {
                // TODO: Add update logic here

                _userAppService.Update(model);
                AjaxModel.Statu = "ok";

            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();
            }
            return Json(AjaxModel);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add update logic here

                _userAppService.Del(id);
                AjaxModel.Statu = "ok";

            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();
            }
            return Json(AjaxModel);

        }

        // POST: Admin/User/Delete/5
        [HttpGet]
        [Create]
        public ActionResult RoleList(int id)
        {
            ViewBag.UserId = id;
            var backUserRole = _roleService.GetUserRole(id);

            return PartialView(backUserRole);
        }
        [HttpPost]
        [Create]
        public ActionResult RoleList(FormCollection form)
        {
            string urUId = form["urUId"];
            string[] urRId = form["urRId"].Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            List<UserRoleDto> list = new List<UserRoleDto>();
            for (int i = 0; i < urRId.Length; i++)
            {
                list.Add(new UserRoleDto { urUId = int.Parse(urUId), urRId = int.Parse(urRId[i]), urAddtime = DateTime.Now });
            }


            if (_roleService.AddUserRole(list))
            {
                AjaxModel.Statu = "ok";

            }
            else
            {
                AjaxModel.Statu = "err";

            }
            return Json(AjaxModel);
        }


        [HttpGet]
        [Create]
        public ActionResult UserPer(int id)
        {
            var isOk = _perService.GetPerBtn(id,1);
            ViewBag.roleId = id;
            return View(isOk);


        }
        [HttpPost]
        [Create]
        public ActionResult UserPer(List<PermissionButtonDto> list)
        {

            list = list.Where(x => x.pbPId > 0).ToList();

            try
            {
                if (_perService.InsertPerButton(list))
                    AjaxModel.Statu = "ok";
                else
                    AjaxModel.Statu = "err";
            }
            catch (Exception)
            {

                AjaxModel.Statu = "err";
            }

            return Json(AjaxModel);
        }
    }
}
