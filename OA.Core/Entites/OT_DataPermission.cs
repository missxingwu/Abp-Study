//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA.Entites
{

    using Abp.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class OT_DataPermission : Entity
    {
        [Key]
        public Guid ObjectID { get; set; }
        public string ParentObjectID { get; set; }
        public string ColumnName { get; set; }
        public Nullable<bool> Visible { get; set; }
        public Nullable<bool> Editable { get; set; }
        public Nullable<bool> Required { get; set; }
        public Nullable<int> ParentIndex { get; set; }
    }
}
