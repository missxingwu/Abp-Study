using AutoMapper;
using OA.DepartmentsDto;
using OA.Entites;
using OA.PermissionsDto;
//using OA.RolePermissionsDto;
using OA.RolesDto;
using OA.UserDto;

namespace OA.AutoMapper
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            Mapper.Initialize(cfg =>
                {
                    ///权限
                    cfg.CreateMap<UserInfoDto, Q_UserInfo>();
                    cfg.CreateMap<RoleDto, Q_Role>();
                    cfg.CreateMap<DepartmentDto, Q_Department>();
                    cfg.CreateMap<UserRoleDto, Q_UserRole>();
                    cfg.CreateMap<PermissionDto, Q_Permission>();
                    //cfg.CreateMap<RolePermissionDto, Q_RolePermission>();
                    //cfg.CreateMap<UserVipPermissionDto, Q_UserVipPermission>();
                    cfg.CreateMap<PermissionButtonDto, Q_PermissionButton>();
                    


                    cfg.CreateMap<Q_UserInfo, UserInfoDto>();
                    cfg.CreateMap<Q_Role, RoleDto>();
                    cfg.CreateMap<Q_Department, DepartmentDto>();
                    cfg.CreateMap<Q_UserRole, UserRoleDto>();
                    cfg.CreateMap<Q_Permission, PermissionDto>();
                    //cfg.CreateMap<Q_RolePermission, RolePermissionDto>();
                    //cfg.CreateMap<Q_UserVipPermission, UserVipPermissionDto>();
                    cfg.CreateMap<Q_PermissionButton, PermissionButtonDto>();
                    ///
                    cfg.CreateMap<PermissionDto, PermissionButtonDto>().ForMember(d => d.pbPId, opt => opt.MapFrom(s => s.pid)).ForMember(d => d.pbPName, opt => opt.MapFrom(s => s.pName));
                    ///工作流

                });
        }
    }
}
