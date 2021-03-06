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

    public partial class OT_InstanceContext : Entity
    {
        public OT_InstanceContext()
        {
            this.OT_WorkItem = new HashSet<OT_WorkItem>();
            this.OT_Token = new HashSet<OT_Token>();
        }
        [Key]
        public Guid ObjectID { get; set; }
        public string ParentInstanceID { get; set; }
        public string SequenceNo { get; set; }
        public string WorkflowPackage { get; set; }
        public string WorkflowName { get; set; }
        public Nullable<int> WorkflowVersion { get; set; }
        public Nullable<bool> State { get; set; }
        public string NextTokenId { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public string BusinessTable { get; set; }
        public string Originator { get; set; }

        public virtual ICollection<OT_WorkItem> OT_WorkItem { get; set; }
        public virtual ICollection<OT_Token> OT_Token { get; set; }
    }
}
