using Abp.Web.Mvc.Controllers;
using OA.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Unity.ComDto;
using static Unity.OaEnums;
using OA.PermissionsDto;

namespace OA.Web.Context
{
    public class AdminBaseController : AbpController
    {
        #region 0.0 基础公用数据
        /// <summary>
        /// 是否ajax请求
        /// </summary>
        public bool isAjax { get; set; }

        /// <summary>
        /// 用户数据
        /// </summary>
        public UserInfoDto User;

        /// <summary>
        /// 用户权限
        /// </summary>
        public static Dictionary<List<PermissionDto>, List<PermissionButtonDto>> baseListPermission;

        /// <summary>
        /// ajax格式数据
        /// </summary>
        public AjaxMsgModel AjaxModel = new AjaxMsgModel();
        public JsonResult backJson = new JsonResult();

        #endregion


        // GET: AdminBase OnAuthorization
        protected AdminBaseController()
        {
            LocalizationSourceName = OAConsts.LocalizationSourceName;

        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData["user"] = User;
            Session["user"] = User;
            ViewData["LeftMenu"] = null;
            if (User != null)
            {
                ViewData["LeftMenu"] = baseListPermission.Keys.First();
            }

            backJson.Data = AjaxModel;
            backJson.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            base.OnActionExecuting(filterContext);
        }

        #region 1.0 验证方法 - 在 ActionExcuting过滤器之前执行
        /// <summary>
        /// 验证方法 - 在 ActionExcuting过滤器之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            string sheader = Request.Headers["X-Requested-With"];
            //XMLHttpRequest
            isAjax = (sheader != null && sheader.ToLower().Equals("xmlhttprequest")) ? true : false;

            if (Session["user"] != null)
            {
                User = Session["user"] as UserInfoDto;

            }

            //1.如果请求的 Admin 区域里的 控制器类和方法，那么就要验证权限
            if (filterContext.RouteData.DataTokens.Keys.Contains("area")//当前请求匹配的 路由对象中 是否 有 area区域
                && filterContext.RouteData.DataTokens["area"].ToString().ToLower() == "admin")//监测区域名 是否为 admin
            {
                //2.检查 被请求的 方法 和 控制器是否有 Skip 标签，如果有，则不验证；如果没有，则验证
                if (!filterContext.ActionDescriptor.IsDefined(typeof(Context.SkipAttribute), false) &&
                    !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(Context.SkipAttribute), false))
                {
                    #region 1.验证用户是否登陆(Session && Cookie)
                    //1.验证用户是否登陆(Session && Cookie)
                    if (User == null)
                    {
                        if (isAjax)
                        {
                            AjaxModel.BackUrl = "/admin/login/index";
                            AjaxModel.Statu = "err";
                            AjaxModel.Msg = "没有登录";
                            JsonResult res = new JsonResult();
                            res.Data = AjaxModel;
                            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                            filterContext.Result = res;
                        }
                        else
                        {
                            filterContext.Result = Redirect("/admin/login/index");
                        }

                    }
                    else if (baseListPermission == null)
                    {
                        if (isAjax)
                        {
                            AjaxModel.BackUrl = "/admin/login/index";
                            AjaxModel.Statu = "err";
                            AjaxModel.Msg = "没有权限";
                            JsonResult res = new JsonResult();
                            res.Data = AjaxModel;
                            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                            filterContext.Result = res;
                        }
                        else
                        {
                            filterContext.Result = Redirect("/admin/login/index");
                            //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Common", controller = "Error", action = "Page400" }));
                        }
                    }
                    #endregion

                    #region 2.验证登陆用户 是否有访问该页面的权限
                    else
                    {
                        //2.获取 登陆用户权限
                        string strAreaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
                        string strContrllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
                        string strActionName = filterContext.ActionDescriptor.ActionName.ToLower();
                        string strHttpMethod = filterContext.HttpContext.Request.HttpMethod.ToLower();
                        //var listPermission = Session["pemission"] as List<PermissionDto>;
                        var leftPer = baseListPermission.Keys.First();
                        var butPer = baseListPermission.Values.First();
                        //int back = leftPer.FindIndex(x => x.pAreaName.ToLower() == strAreaName && x.pControllerName.ToLower() == strContrllerName & x.pActionName.ToLower() == strActionName &&
                        //(x.pFormMethod == (int)(ChartDataType)Enum.Parse(typeof(ChartDataType), strHttpMethod) || x.pFormMethod == 2));

                        var back = leftPer.FirstOrDefault(x => x.pAreaName.ToLower() == strAreaName && x.pControllerName.ToLower() == strContrllerName);
                        if (back != null)
                        {

                            var bbbbb = butPer.First(x => x.pbPId == back.pid);
                            ViewData["basebutton"] = bbbbb;
                            bool isOkper = false;

                            if (strActionName == "index" || filterContext.ActionDescriptor.IsDefined(typeof(Context.SkipAttribute), false) || filterContext.ActionDescriptor.IsDefined(typeof(Context.IndexAttribute), false))
                            {
                                isOkper = true;
                            }
                            else if (strActionName == "create" || filterContext.ActionDescriptor.IsDefined(typeof(Context.SkipAttribute), false) || filterContext.ActionDescriptor.IsDefined(typeof(Context.CreateAttribute), false))
                            {
                                isOkper = true;
                            }
                            else if (strActionName == "edit" || filterContext.ActionDescriptor.IsDefined(typeof(Context.SkipAttribute), false) || filterContext.ActionDescriptor.IsDefined(typeof(Context.EditAttribute), false))
                            {
                                isOkper = true;
                            }
                            else if (strActionName == "delete" || filterContext.ActionDescriptor.IsDefined(typeof(Context.CreateAttribute), false) || filterContext.ActionDescriptor.IsDefined(typeof(Context.DeleteAttribute), false))
                            {
                                isOkper = true;
                            }
                            else if (strActionName == "setbutton" || filterContext.ActionDescriptor.IsDefined(typeof(Context.CreateAttribute), false) || filterContext.ActionDescriptor.IsDefined(typeof(Context.SetButtonAttribute), false))
                            {
                                isOkper = true;
                            }
                            else if (strActionName == "setpermission" || filterContext.ActionDescriptor.IsDefined(typeof(Context.CreateAttribute), false) || filterContext.ActionDescriptor.IsDefined(typeof(Context.SetPermissionAttribute), false))
                            {
                                isOkper = true;
                            }
                            else if (strActionName == "changerpwd" || filterContext.ActionDescriptor.IsDefined(typeof(Context.CreateAttribute), false) || filterContext.ActionDescriptor.IsDefined(typeof(Context.ChangePwdAttribute), false))
                            {
                                isOkper = true;
                            }
                            else if (strActionName == "deleteall" || filterContext.ActionDescriptor.IsDefined(typeof(Context.CreateAttribute), false) || filterContext.ActionDescriptor.IsDefined(typeof(Context.DeleteAllAttribute), false))
                            {
                                isOkper = true;
                            }
                            else
                            {
                                isOkper = false;
                            }

                            if (!isOkper)
                            {
                                if (isAjax)
                                {
                                    AjaxModel.BackUrl = "/admin/login/index?msg=noPermission";
                                    AjaxModel.Statu = "err";
                                    AjaxModel.Msg = "没有访问该页面权限";
                                    JsonResult res = new JsonResult();
                                    res.Data = AjaxModel;
                                    res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                                    filterContext.Result = res;
                                }
                                else
                                {
                                    filterContext.Result = Redirect("/admin/login/index?msg=noPermission");
                                }
                            }



                        }
                        else
                        {
                            if (isAjax)
                            {
                                AjaxModel.BackUrl = "/admin/login/index?msg=noPermission";
                                AjaxModel.Statu = "err";
                                AjaxModel.Msg = "没有访问该页面权限";
                                JsonResult res = new JsonResult();
                                res.Data = AjaxModel;
                                res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                                filterContext.Result = res;
                            }
                            else
                            {
                                filterContext.Result = Redirect("/admin/login/index?msg=noPermission");
                            }
                        }

                    }
                    #endregion
                }

            }
        }

        #endregion
    }
}