using OA.DepartmentsDto;
using OA.RolesDto;
using OA.Web.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Areas.Admin.Controllers
{
    //  [Skip]
    public class DepartmentController : AdminBaseController
    {
        private readonly IDepartmentAppService _appService;
        private readonly IRoleAppService _appRoleService;
        public DepartmentController(IDepartmentAppService appService, IRoleAppService appRoleService)
        {
            _appService = appService;
            _appRoleService = appRoleService;
        }

        #region 0.0 部门操作
        // GET: Admin/Department
        public ActionResult Index()
        {
            var back = _appService.GetList();

            return View(back);
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Department/Create
        [HttpGet]
        public ActionResult Create()
        {
            var back = _appService.GetListTree();
            ViewData["depList"] = back;
            return PartialView();
        }

        // POST: Admin/Department/Create
        [HttpPost]
        public ActionResult Create(DepartmentDto model)
        {
            try
            {
                // TODO: Add insert logic here
                model.depAddTime = DateTime.Now;
                _appService.Insert(model);
                AjaxModel.Statu = "ok";

            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();
            }
            return Json(AjaxModel);
        }

        // GET: Admin/Department/Edit/5
        public ActionResult Edit(int id)
        {
            var back = _appService.GetListTree();
            ViewData["depList"] = back;
            var model = _appService.GetList(id).FirstOrDefault();
            return PartialView("Create", model);
        }

        // POST: Admin/Department/Edit/5
        [HttpPost]
        public ActionResult Edit(DepartmentDto model)
        {
            try
            {
                // TODO: Add insert logic here
                //  model.depAddTime = DateTime.Now;
                _appService.Update(model);
                AjaxModel.Statu = "ok";

            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();
            }
            return Json(AjaxModel);
        }

        // GET: Admin/Department/Delete/5
        public ActionResult Delete(int id)
        {
            var back = _appService.Del(id);
            if (back)
            {
                AjaxModel.Statu = "ok";
                //return Content("ok");
            }
            else
            { AjaxModel.Statu = "err"; }
            return backJson;
        }




        #endregion

        #region 0.1 角色操作
        public ActionResult RoleIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RoleCreate(int id)
        {
            var back = _appService.GetListTree();
            ViewData["depList"] = back;
            RoleDto model = new RoleDto { rDepId = id };
            var listModel = _appRoleService.GetList(id);
            ViewData["List"] = listModel;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult RoleCreate(RoleDto model)
        {
            bool back = false;
            try
            {
                // TODO: Add update logic here
                if (model.rId > 0)
                {
                    back = _appRoleService.Update(model);
                }
                else
                {
                    back = _appRoleService.Insert(model);
                }

                if (back)
                    return Content("ok");
                else
                    return Content("err");

            }
            catch
            {
                return Content("err");
            }
        }

        public JsonResult RoleEdit(int id)
        {
            try
            {
                var back = _appRoleService.GetModel(id);
                AjaxModel.Data = back;
                AjaxModel.Statu = "ok";
            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();

            }

            return Json(AjaxModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RoleDel(int id)
        {
            try
            {
                _appRoleService.Del(id);
                AjaxModel.Statu = "ok";
            }
            catch (Exception)
            {

                AjaxModel.Statu = "err";
            }
            return Json(AjaxModel, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
