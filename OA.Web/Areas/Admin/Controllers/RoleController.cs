using OA.DepartmentsDto;
using OA.PermissionsDto;
using OA.RolesDto;
using OA.Web.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OA.Web.Areas.Admin.Controllers
{
    //[Skip]
    public class RoleController : AdminBaseController
    {
        private readonly IRoleAppService _appService;
        private readonly IDepartmentAppService _paService;
        private readonly IPermissionAppService _perService;
        //private readonly IRolePermissionAppService _rolePerService;
        public RoleController(IRoleAppService appService, IDepartmentAppService paService, IPermissionAppService perService)
        {
            _appService = appService;
            _paService = paService;
            _perService = perService;
            //_rolePerService = rolePerService;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {

            var list = _appService.GetList(0);
            if (isAjax)
            {
                //limit: undefined, start: undefined, page: NaN

                //PageModel page = new PageModel()
                //{
                //    iTotalDisplayRecords= list.Count,
                //    iTotalRecords = 10,
                //    aaData = list.Skip(0).Take(10).Select(x => new[] { x.rId.ToString(), x.depName, x.rName, x.rRemark, x.rIsShow.ToString() }).ToList(),

                //};
                var backData = list.Skip(0).Take(10).Select(x => new[] { x.rId.ToString(), x.depName, x.rName, x.rRemark, x.rIsShow.ToString() });
                return Json(new
                {
                    sEcho = "",
                    iDisplayStart = "",
                    iTotalRecords = list.Count,
                    iTotalDisplayRecords = list.Count,
                    aaData = backData



                    //iTotalRecords = 10,
                    //iTotalDisplayRecords = list.Count,
                    //aaData = backData
                }, JsonRequestBehavior.AllowGet);
                //  return Json(page,JsonRequestBehavior.AllowGet);
            }
            return View(list);
        }

        // GET: Admin/Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Role/Create
        public ActionResult Create()
        {
            var back = _paService.GetListTree();
            ViewData["depList"] = back;
            return View();
        }

        // POST: Admin/Role/Create
        [HttpPost]
        public ActionResult Create(RoleDto model)
        {

            if (_appService.Insert(model))
            {
                AjaxModel.Statu = "ok";

            }
            else
            {
                AjaxModel.Statu = "err";
            }
            return Json(AjaxModel);
        }

        // GET: Admin/Role/Edit/5
        public ActionResult Edit(int id)
        {
            var back = _paService.GetListTree();
            ViewData["depList"] = back;
            var model = _appService.GetList(id).First();
            return PartialView("Create", model);
        }

        // POST: Admin/Role/Edit/5
        [HttpPost]
        public ActionResult Edit(RoleDto model)
        {
            if (_appService.Update(model))
            {
                AjaxModel.Statu = "ok";

            }
            else
            {
                AjaxModel.Statu = "err";
            }
            return Json(AjaxModel);


        }

        // GET: Admin/Role/Delete/5
        public ActionResult Delete(int id)
        {
            if (_appService.Del(id))
            {
                AjaxModel.Statu = "ok";

            }
            else
            {
                AjaxModel.Statu = "err";
            }
            return Json(AjaxModel, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [Create]
        public ActionResult PermissonList(int id)
        {

            var isOk = _perService.GetPerBtn(id, 0);
            ViewBag.roleId = id;
            return View(isOk);
        }
        [HttpPost]
        [Create]
        public ActionResult PermissonList(List<PermissionButtonDto> list)
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
        //public ActionResult PermissonList(FormCollection form)
        //{
        //    try
        //    {
        //        int rpRId = int.Parse(form["rpRId"]);
        //        string[] rpPId = form["rpPId"].Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        //        List<RolePermissionDto> list = new List<RolePermissionDto>();
        //        foreach (var item in rpPId)
        //        {
        //            list.Add(new RolePermissionDto { rpRId = rpRId, rpPId = int.Parse(item), rpAddTime = DateTime.Now, rpIsDel = false });
        //        }
        //        if (_rolePerService.Insert(list))
        //            AjaxModel.Statu = "ok";
        //        else
        //            AjaxModel.Statu = "err";
        //    }
        //    catch (Exception)
        //    {

        //        AjaxModel.Statu = "err";
        //    }

        //    return Json(AjaxModel);
        //}
    }
}
