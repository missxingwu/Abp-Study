using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.UserDto
{
    public class UserInfoDto: EntityDto
    {
        public int uId { get; set; }
        public Nullable<int> uDepId { get; set; }
        public string uLoginName { get; set; }
        public string uName { get; set; }
        public string uEmail { get; set; }
        public string uPwd { get; set; }
        public Nullable<bool> uGender { get; set; }
        public string uPost { get; set; }
        public string uRemark { get; set; }
        public string uAddress { get; set; }
        public Nullable<bool> uIsDel { get; set; }
        public Nullable<System.DateTime> uAddTime { get; set; }
    }

    //public class UserVipPermissionDto : EntityDto
    //{
    //    public int vipId { get; set; }
    //    public Nullable<int> vipUserId { get; set; }
    //    public Nullable<int> vipPermission { get; set; }
    //    public string vipRemark { get; set; }
    //    public Nullable<bool> vipIsDel { get; set; }
    //    public Nullable<System.DateTime> vipAddTime { get; set; }
       
    //}
}
