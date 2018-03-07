using Abp.Application.Services;
using OA.PermissionsDto;
using OA.UserDto;
using System.Collections.Generic;

namespace OA.WorkContextDto
{
    public interface IWorkContextAppService: IApplicationService
    {
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="strAreaName">区域名</param>
        /// <param name="strContrllerName">控制名称</param>
        /// <param name="strActionName">方法</param>
        /// <param name="strHttpMethod">请求方式</param>
        /// <returns></returns>
        Dictionary<List<PermissionDto>, List<PermissionButtonDto>> HasPemission(UserInfoDto user);
    }
}
