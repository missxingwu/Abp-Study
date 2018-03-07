using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA.Web.Context
{
    /// <summary>
    /// 跳过权限验证
    /// </summary>
    public class SkipAttribute : Attribute
    {
    }

    /// <summary>
    /// 为Ajax请求的目标 设置的标记（特性）
    /// </summary>
    public class AjaxRequestAttribute : Attribute
    {
    }
    public class IndexAttribute : Attribute
    {
    }
    public class CreateAttribute : Attribute
    {
    }
    public class EditAttribute : Attribute
    {
    }
    public class DeleteAttribute : Attribute
    {
    }
    public class SetButtonAttribute : Attribute
    {
    }
    public class SetPermissionAttribute : Attribute
    {
    }
    public class ChangePwdAttribute : Attribute
    {
    }
    public class DeleteAllAttribute : Attribute
    {
    }
}