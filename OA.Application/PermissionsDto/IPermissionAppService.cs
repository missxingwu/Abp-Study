using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.PermissionsDto
{
    public interface IPermissionAppService : IApplicationService
    {
        PermissionDto Get(int id);
        List<PermissionDto> GetAll();
        List<PermissionDto> GetAllTree();
        bool Insert(PermissionDto model);

        bool Update(PermissionDto model);

        bool Delete(int id);

        bool InsertPerButton(List<PermissionButtonDto> list);

        List<PermissionButtonDto> GetPerBtn(int id,int state);
    }
}
