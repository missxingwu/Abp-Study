using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.RolePermissionsDto
{
    public class RolePermissionDto : EntityDto
    {
        public int rpId { get; set; }
        public Nullable<int> rpRId { get; set; }
        public Nullable<int> rpPId { get; set; }
        public Nullable<bool> rpIsDel { get; set; }
        public Nullable<System.DateTime> rpAddTime { get; set; }
       
    }
}