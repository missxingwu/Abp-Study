using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entites
{
    public class Q_PermissionButton: Entity
    {
        public Nullable<int> UorRId { get; set; }
        public Nullable<int> pbPId { get; set; }
        public Nullable<int> pbUorRStatr { get; set; }
        /// <summary>
        /// 浏览
        /// </summary>
        public Nullable<bool> pbIndex { get; set; }
        /// <summary>
        /// 新增
        /// </summary>
        public Nullable<bool> pbCreate { get; set; }
        /// <summary>
        /// 编辑
        /// </summary>
        public Nullable<bool> pbEdit { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public Nullable<bool> pbDelete { get; set; }
        /// <summary>
        /// 设置按钮
        /// </summary>
        public Nullable<bool> pbSetButton { get; set; }
        /// <summary>
        /// 设置权限
        /// </summary>
        public Nullable<bool> pbSetPermission { get; set; }
        /// <summary>
        /// 修改密码
        /// </summary>
        public Nullable<bool> pbChangePwd { get; set; }
        /// <summary>
        /// 删除全部
        /// </summary>
        public Nullable<bool> pbDeleteAll { get; set; }
        public Nullable<System.DateTime> pbAddTime { get; set; }
        public virtual Q_Permission Q_Permission { get; set; }
    }
}
