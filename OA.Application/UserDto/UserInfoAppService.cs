using Abp.Domain.Repositories;
using AutoMapper;
//using AutoMapper;
using OA.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.UserDto
{
    public class UserInfoAppService : OAAppServiceBase, IUserInfoAppService
    {
        private readonly IRepository<Q_UserInfo> _userRepository;
        private readonly IRepository<Q_Department> _drpRepository;
      
        public UserInfoAppService(IRepository<Q_UserInfo> UserRepository, IRepository<Q_Department> drpRepository)
        {
            _userRepository = UserRepository;
            _drpRepository = drpRepository;
          
        }

        public List<UserInfoDto> GetList(int id)
        {
            var list = _userRepository.GetAllList();
            var alist = Mapper.Map<List<UserInfoDto>>(list);
            if (id > 0)
            {
                alist = new List<UserInfoDto>();
                var back = _userRepository.GetAll().First(u => u.uId == id);
                alist.Add(Mapper.Map<UserInfoDto>(back));
            }
            return alist;
        }

        public bool Insert(UserInfoDto model)
        {
            model.uAddTime = DateTime.Now;
            var olModel = Mapper.Map<Q_UserInfo>(model);          
            var back = _userRepository.InsertAndGetId(olModel);
            return back > 0;
        }

        public bool Update(UserInfoDto model)
        {
            var olmodel = _userRepository.GetAll().First(u => u.uId == model.uId);

            try
            {
                olmodel.uRemark = model.uRemark;
                olmodel.uName = model.uName;
                olmodel.uLoginName = model.uLoginName;
                olmodel.uEmail = model.uEmail;
                olmodel.uGender = model.uGender;
                olmodel.uIsDel = model.uIsDel;
                olmodel.uPwd = model.uPwd;
                olmodel.uDepId = model.uDepId;              
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
            var olmodel = _userRepository.GetAll().First(u => u.uId == id);
            try
            {
                _userRepository.Delete(olmodel);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        
    }
}
