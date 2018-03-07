using OA.PermissionsDto;
using OA.Web.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Web.Areas.Admin.Controllers
{
    [Skip]
    public class PermissionController : AdminBaseController
    {
        private readonly IPermissionAppService _service;

        public PermissionController(IPermissionAppService service)
        {
            _service = service;
        }
        // GET: Admin/Permission
        public ActionResult Index()
        {
            var back = _service.GetAll();
            return View(back);
        }
        public ActionResult VueIndex()
        {
            
            return View();
        }
       
        // GET: Admin/Permission/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Permission/Create
        public ActionResult Create()
        {
            var back = _service.GetAllTree();
            back.Insert(0, new PermissionDto() { Id = 0, pName = "总公司" });
            ViewData["parentid"] = back;
            return View();
        }

        // POST: Admin/Permission/Create
        [HttpPost]
        public ActionResult Create(PermissionDto model)
        {
            try
            {
                _service.Insert(model);
                // TODO: Add insert logic here

                AjaxModel.Statu = "ok";

            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();
            }
            return Json(AjaxModel);
        }

        // GET: Admin/Permission/Edit/5
        public ActionResult Edit(int id)
        {
            var back = _service.GetAllTree();
            back.Insert(0, new PermissionDto() { Id = 0, pName = "总公司" });
            ViewData["parentid"] = back;
            var backModel = _service.Get(id);
            return PartialView("Create", backModel);
        }

        // POST: Admin/Permission/Edit/5
        [HttpPost]
        public ActionResult Edit(PermissionDto model)
        {
            try
            {
                _service.Update(model);
                // TODO: Add insert logic here

                AjaxModel.Statu = "ok";

            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();
            }
            return Json(AjaxModel);
        }

        // GET: Admin/Permission/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                // TODO: Add insert logic here

                AjaxModel.Statu = "ok";

            }
            catch (Exception ex)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = ex.ToString();
            }
            return backJson;
        }

        // POST: Admin/Permission/Delete/5

    }
}
