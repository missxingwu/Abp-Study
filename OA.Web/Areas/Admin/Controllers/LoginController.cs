using Abp.BackgroundJobs;
using OA.AllEventBus;
using OA.RolesDto;
using OA.UserDto;
using OA.Web.Context;
using OA.WorkContextDto;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OA.Web.Areas.Admin.Controllers
{
    [Skip]
    public class LoginController : AdminBaseController
    {
        private readonly IUserInfoAppService _userAppService;
        private readonly IRoleAppService _roleService;
        private readonly IWorkContextAppService _perservice;
        private readonly IBackgroundJobManager _backgroundJobManager;
        public LoginController(IUserInfoAppService userAppService, IRoleAppService roleService, IWorkContextAppService perservice, IBackgroundJobManager backgroundJobManager)
        {
            _userAppService = userAppService;
            _roleService = roleService;
            _perservice = perservice;
            _backgroundJobManager = backgroundJobManager;
        }

        [HttpGet]
        // GET: Admin/Login
        public ActionResult Index()
        {
            ViewData["Msg"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserInfoDto model)
        {
            var list = _userAppService.GetList(0).Where(x => x.uLoginName == model.uLoginName).ToList();

            if (list.Count < 1)
            {
                AjaxModel.Statu = "err";
                AjaxModel.Msg = "登录名错误";
            }
            else
            {
                try
                {
                    string pwd = model.uPwd;

                    var user = list.First(x => x.uPwd == pwd);
                    if (user == null)
                    {
                        AjaxModel.Statu = "err";
                        AjaxModel.Msg = "密码错误";
                    }
                    else
                    {
                        Session["user"] = user;
                        baseListPermission = _perservice.HasPemission(user);
                        AjaxModel.BackUrl = "/admin/admin/index";
                        AjaxModel.Statu = "ok";
                        AjaxModel.Msg = "登陆成功!";

                    }
                }
                catch (Exception ex)
                {
                    AjaxModel.Statu = "err";
                    AjaxModel.Msg = "密码错误";
                }
            }
            SimpleSendEmailJobArgs aa = new SimpleSendEmailJobArgs
            {
                SenderUserId = 2,
                TargetUserId = 2,
                Body = "测试",
                Subject = "测试"

            };
            _backgroundJobManager.Enqueue<SimpleSendEmailJob, SimpleSendEmailJobArgs>(aa,BackgroundJobPriority.Normal);
            if (base.isAjax)
            {
                return Json(AjaxModel);
            }
            else
            {
                return Redirect("/admin/user/index");
            }

        }
    }
}