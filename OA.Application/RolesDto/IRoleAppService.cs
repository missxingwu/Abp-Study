using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.RolesDto
{
    public interface IRoleAppService : IApplicationService
    {
        List<RoleDto> GetList(int id);
        RoleDto GetModel(int id);
        bool Insert(RoleDto model);
        bool Update(RoleDto model);
        bool Del(int id);

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<RoleDto> GetUserRole(int id);

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool AddUserRole(List<UserRoleDto> list);
    }
}
