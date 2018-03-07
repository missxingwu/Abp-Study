using Abp.Domain.Repositories;
using AutoMapper;
//using AutoMapper;
using OA.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.RolesDto
{
    public class RoleAppService : OAAppServiceBase, IRoleAppService
    {
        private readonly IRepository<Q_Role> _userRepository;
        private readonly IRepository<Q_Department> _drpRepository;
        private readonly IRepository<Q_UserRole> _userRole;
        public RoleAppService(IRepository<Q_Role> UserRepository, IRepository<Q_Department> drpRepository, IRepository<Q_UserRole> userRole)
        {
            _userRepository = UserRepository;
            _drpRepository = drpRepository;
            _userRole = userRole;
        }

        public List<RoleDto> GetList(int id)
        {
            var list = _userRepository.GetAll().ToList();
            var drpList=  _drpRepository.GetAll().ToList();
            if (id > 0)
            {
                list = list.Where(x => x.rId == id).ToList();
            }
            var alist = Mapper.Map<List<RoleDto>>(list);

            alist.ForEach(x => {
                var dp = drpList.Find(z => z.depId == x.rDepId);
                if (dp != null)
                    x.depName = dp.depName;
            });
          
            return alist;
        }

        public bool Insert(RoleDto model)
        {

            //var bb=Mapper.Map<Q_UserInfo>(model);
            //Q_UserInfo olModel = new Q_UserInfo
            //{
            //    uAddTime = DateTime.Now,
            //    uId = model.uId,
            //    uDepId = model.uDepId,
            //    uGender = model.uGender,
            //    uLoginName = model.uLoginName,
            //    uPost = model.uPost,
            //    uRemark = model.uRemark,
            //    uPwd = model.uPwd,
            //    uIsDel = model.uIsDel,
            //};

            try
            {
                var olModel = Mapper.Map<Q_Role>(model);
                //olModel.Q_Department = _drpRepository.GetAll().First(x => x.depId == model.rDepId.Value);
                _userRepository.InsertAndGetId(olModel);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Update(RoleDto model)
        {
            var olmodel = _userRepository.FirstOrDefault(x => x.rId == model.rId);
            try
            {
                olmodel.rName = model.rName;
                olmodel.rRemark = model.rRemark;
                olmodel.rIsDel = model.rIsDel;
                olmodel.rIsShow = model.rIsShow;
                olmodel.rDepId = model.rDepId;
                // olmodel.Q_Department = _drpRepository.GetAll().First(x => x.depId == model.rDepId.Value);
                _userRepository.Update(olmodel);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool Del(int id)
        {          
            var olmodel = _userRepository.FirstOrDefault(x => x.rId == id);
            try
            {
                _userRepository.Delete(olmodel);
                return true;
            }
            catch (Exception)
            {

                return false; ;
            }
        }

        public RoleDto GetModel(int id)
        {
            var list = _userRepository.FirstOrDefault(x => x.rId == id);
            var back = Mapper.Map<RoleDto>(list);
            return back;
        }

        public List<RoleDto> GetUserRole(int id)
        {
            var backlist = _userRepository.GetAll().Where(x => x.rIsShow == true && x.rIsDel == false).ToList();
            var back = Mapper.Map<List<RoleDto>>(backlist.ToList());
            back.ForEach(x =>
            {
                var gg = backlist.Find(z => z.rId == x.rId);
                if (gg != null)
                    x.depName = _drpRepository.FirstOrDefault(d => d.depId == x.rDepId.Value).depName;
            });

            var userRole = _userRole.GetAllList(x => x.urUId == id);
            if (userRole != null && userRole.Count > 0)
            {
                back.ForEach(x =>
                {
                    var gg = userRole.Find(z => z.urRId == x.rId);
                    if (gg != null)
                        x.rIsDel = true;
                });
            }

            return back;



            // return null;
        }

        public bool AddUserRole(List<UserRoleDto> list)
        {
            try
            {
                var back = Mapper.Map<List<Q_UserRole>>(list);
                var uid = list.First().urUId;
                if (_userRole.Count(u => u.urUId == uid) > 0)
                {
                    _userRole.Delete(u => u.urUId == uid);
                }
                foreach (var item in back)
                {
                    item.urIsDel = false;
                    _userRole.Insert(item);
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
