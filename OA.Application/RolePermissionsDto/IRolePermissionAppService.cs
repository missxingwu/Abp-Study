using Abp.Application.Services;
using System.Collections.Generic;


namespace OA.RolePermissionsDto
{
    public interface IRolePermissionAppService : IApplicationService
    {
        List<RolePermissionDto> GetAll(int id);

        bool Insert(List<RolePermissionDto> list);

    }
}
