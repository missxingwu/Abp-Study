using Abp.Domain.Repositories;
using AutoMapper;
using OA.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.RolePermissionsDto
{
    public class RolePermissionAppService : OAAppServiceBase, IRolePermissionAppService
    {
        private readonly IRepository<Q_RolePermission> _roleRepository;

        public RolePermissionAppService(IRepository<Q_RolePermission> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<RolePermissionDto> GetAll(int id)
        {
            var back = _roleRepository.GetAll();
            if (id > 0)
            {
                back= back.Where(x => x.rpRId == id && x.rpIsDel == false);
            }
            return Mapper.Map<List<RolePermissionDto>>(back.ToList());
        }

        public bool Insert(List<RolePermissionDto> list)
        {
            try
            {
                int rpRId = list.First().rpRId.Value;
                if (_roleRepository.Count(x => x.rpRId == rpRId) > 0)
                {
                    _roleRepository.Delete(x => x.rpRId == rpRId);
                }
                foreach (var item in list)
                {
                    _roleRepository.Insert(Mapper.Map<Q_RolePermission>(item));
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
        }
    }
}
