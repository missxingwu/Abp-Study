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

    public partial class Q_Role : Entity
    {
        public Q_Role()
        {
          
            this.Q_UserRole = new HashSet<Q_UserRole>();
        }
        [Key]
        public int rId { get; set; }
        public Nullable<int> rDepId { get; set; }
        public string rName { get; set; }
        public string rRemark { get; set; }
        public Nullable<bool> rIsShow { get; set; }
        public Nullable<bool> rIsDel { get; set; }
        public Nullable<System.DateTime> rAddTime { get; set; }

        public virtual Q_Department Q_Department { get; set; }
      
        public virtual ICollection<Q_UserRole> Q_UserRole { get; set; }
    }
}