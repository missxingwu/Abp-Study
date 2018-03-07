using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.UserDto
{
    public interface IUserInfoAppService : IApplicationService
    {
        List<UserInfoDto> GetList(int id);

        bool Insert(UserInfoDto model);
        bool Update(UserInfoDto model);
        bool Del(int id);
    }
}
