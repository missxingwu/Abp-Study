//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA.Entites
{
    using Abp.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Q_Permission : Entity
    {
       
        [Key]
        public virtual int pid { get; set; }
        public  Nullable<int> pParent { get; set; }
        public string pName { get; set; }
        public string pAreaName { get; set; }
        public string pControllerName { get; set; }
        public string pActionName { get; set; }
        public short pFormMethod { get; set; }
        public short pOperationType { get; set; }
        public string pIco { get; set; }
        public  Nullable<int> pOrder { get; set; }
        public  Nullable<bool> pIsLink { get; set; }
        public string pLinkUrl { get; set; }
        public  Nullable<bool> pIsShow { get; set; }
        public string pRemark { get; set; }
        public  Nullable<bool> pIsDel { get; set; }
        public Nullable<System.DateTime> pAddTime { get; set; }

     
    }
}