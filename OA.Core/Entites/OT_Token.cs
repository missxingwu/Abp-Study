//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace  OA.Entites
{
    using Abp.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class OT_Token :Entity
    {
        [Key]
        public Guid ObjectID { get; set; }
        public string InstanceId { get; set; }
        public string TokenId { get; set; }
        public string WorkflowPackage { get; set; }
        public string WorkflowName { get; set; }
        public string Originator { get; set; }
        public string Activity { get; set; }
        public Nullable<int> Approval { get; set; }
        public string Participant { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> FinishedDate { get; set; }
        public string ItemComment { get; set; }
        public string ColumnName { get; set; }
        public Nullable<int> ParticipantType { get; set; }
        public virtual OT_InstanceContext OT_InstanceContext { get; set; }
    }
}
