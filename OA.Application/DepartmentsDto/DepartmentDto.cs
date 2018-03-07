using Abp.Application.Services.Dto;
using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DepartmentsDto
{
    // [AutoMap(typeof(Q_Department))]
    public class DepartmentDto : EntityDto
    {
       // [Key("")]
        public int depId { get; set; }
        public Nullable<int> depPid { get; set; }
        public string depName { get; set; }
        public string depRemark { get; set; }
        public Nullable<bool> depIsDel { get; set; }
        public Nullable<System.DateTime> depAddTime { get; set; }

        public string depPName { get; set; }
    }
}
