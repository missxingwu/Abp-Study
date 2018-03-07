using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.RolesDto
{
    public class RoleDto : EntityDto
    {
        public int rId { get; set; }
        public Nullable<int> rDepId { get; set; }
        public string rName { get; set; }
        public string rRemark { get; set; }
        public bool rIsShow { get; set; }
        public bool rIsDel { get; set; }
        public Nullable<System.DateTime> rAddTime { get; set; }

        public string depName { get; set; }
    }

    public class UserRoleDto : EntityDto
    {
        public int urId { get; set; }
        public int urUId { get; set; }
        public int urRId { get; set; }
        public Nullable<System.DateTime> urAddtime { get; set; }
      
    }
}
