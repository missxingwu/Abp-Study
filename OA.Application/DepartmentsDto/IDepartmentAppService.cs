using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DepartmentsDto
{
    public interface IDepartmentAppService : IApplicationService
    {
        List<DepartmentDto> GetList(int id = 0);

        List<DepartmentDto> GetListTree(int id = 0);

        bool Insert(DepartmentDto model);
        bool Update(DepartmentDto model);
        bool Del(int id);
    }
}
