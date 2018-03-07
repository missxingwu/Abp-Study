using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.PermissionsDto
{
    public class PermissionDto : EntityDto
    {

        public virtual int pid { get; set; }
        public Nullable<int> pParent { get; set; }
        public string pName { get; set; }
        public string pAreaName { get; set; }
        public string pControllerName { get; set; }
        public string pActionName { get; set; }
        public short pFormMethod { get; set; }
        public short pOperationType { get; set; }
        public string pIco { get; set; }
        public Nullable<int> pOrder { get; set; }
        public bool pIsLink { get; set; }
        public string pLinkUrl { get; set; }
        public bool pIsShow { get; set; }
        public string pRemark { get; set; }
        public bool pIsDel { get; set; }
        public Nullable<System.DateTime> pAddTime { get; set; }
    }

    public class PermissionButtonDto : EntityDto
    {
        public Nullable<int> UorRId { get; set; }
        public Nullable<int> pbPId { get; set; }
        public Nullable<int> pbUorRStatr { get; set; }
        public bool pbIsDel { get; set; }
        public string pbPName { get; set; }
        /// <summary>
        /// 浏览
        /// </summary>
        public bool pbIndex { get; set; }
        /// <summary>
        /// 新增
        /// </summary>
        public bool pbCreate { get; set; }
        /// <summary>
        /// 编辑
        /// </summary>
        public bool pbEdit { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public bool pbDelete { get; set; }
        /// <summary>
        /// 设置按钮
        /// </summary>
        public bool pbSetButton { get; set; }
        /// <summary>
        /// 设置权限
        /// </summary>
        public bool pbSetPermission { get; set; }
        /// <summary>
        /// 修改密码
        /// </summary>
        public bool pbChangePwd { get; set; }
        /// <summary>
        /// 删除全部
        /// </summary>
        public bool pbDeleteAll { get; set; }
        public Nullable<System.DateTime> pbAddTime { get; set; }
    }
}
