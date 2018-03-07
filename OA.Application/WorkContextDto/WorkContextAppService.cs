using Abp.Domain.Repositories;
using OA.Entites;
using OA.UserDto;
using System.Collections.Generic;
using System.Linq;
using OA.PermissionsDto;
using AutoMapper;

namespace OA.WorkContextDto
{
    public class WorkContextAppService : OAAppServiceBase, IWorkContextAppService
    {

        private readonly IRepository<Q_PermissionButton> _pbRepository;
        private readonly IRepository<Q_UserRole> _roleRepository;

        private readonly IRepository<Q_Permission> _perMissRepository;
        public WorkContextAppService(IRepository<Q_PermissionButton> pbRepository, IRepository<Q_UserRole> roleRepository, IRepository<Q_Permission> perMissRepository)
        {
            _pbRepository = pbRepository;
            _roleRepository = roleRepository;

            _perMissRepository = perMissRepository;
        }

        public Dictionary<List<PermissionDto>, List<PermissionButtonDto>> HasPemission(UserInfoDto user)
        {
            //用户所有权限
            List<Q_PermissionButton> perAll = new List<Q_PermissionButton>();
            List<int> perMissId = new List<int>();
            /// 获取角色列表
            var roles = _roleRepository.GetAll().Where(x => x.urUId == user.uId).ToList();
            // 所有权限列表
            var rolePermAll = _pbRepository.GetAllList();
            foreach (var item in roles)
            {
                perAll.AddRange(rolePermAll.Where(x => x.UorRId == item.urRId && x.pbUorRStatr == 0).ToList());
            }
            //用户特权列表
            perAll.AddRange(rolePermAll.Where(x => x.UorRId == user.uId && x.pbUorRStatr == 1).ToList());

            //去重
           // perAll.Where((x, i) => perAll.FindIndex(z => z.Id == x.Id) == i);

            Dictionary<List<PermissionDto>, List<PermissionButtonDto>> bk = new Dictionary<List<PermissionDto>, List<PermissionButtonDto>>();

            var pbBack = Mapper.Map<List<PermissionButtonDto>>(perAll);

            var pBack = new List<PermissionDto>();
            pbBack.ForEach(x =>
            {

                pBack.Add(Mapper.Map<PermissionDto>( _perMissRepository.FirstOrDefault(z => z.pid == x.pbPId.Value)));

            });
            bk.Add(pBack, pbBack);
            return bk;
        }
        //public List<PermissionDto> HasPemission(UserInfoDto user)
        //{
        //    List<int> perMissId = new List<int>();
        //    /// 获取角色列表
        //    var roles = _roleRepository.GetAll().Where(x => x.urUId == user.uId).ToList();
        //    // 角色拥有权限列表
        //   // List<Q_RolePermission> rolePer = new List<Q_RolePermission>();
        //    // 所有权限列表
        //    var rolePermAll = _pbRepository.GetAllList();
        //    foreach (var item in roles)
        //    {
        //        rolePer.AddRange(rolePermAll.Where(x => x.rpRId == item.urRId).ToList());
        //    }
        //    perMissId.AddRange(rolePer.Select(x => x.rpPId.Value).ToList());

        //    //用户特权列表
        //    perMissId.AddRange(_vipRepository.GetAll().Where(x => x.vipUserId == user.uId).Select(x => x.vipPermission.Value));

        //    //去重
        //    perMissId = perMissId.Distinct().ToList();

        //    //用户所有权限
        //    List<Q_Permission> perAll = new List<Q_Permission>();
        //    foreach (var item in perMissId)
        //    {
        //        perAll.Add(_perMissRepository.GetAllList().Find(x => x.pid == item));
        //    }

        //    return Mapper.Map<List<PermissionDto>>(perAll);
        //}
    }
}
