using Abp.Domain.Repositories;
using AutoMapper;
//using AutoMapper;
using OA.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DepartmentsDto
{
    public class DepartmentAppService : OAAppServiceBase, IDepartmentAppService
    {
        private readonly IRepository<Q_Department> _userRepository;

        public DepartmentAppService(IRepository<Q_Department> UserRepository)
        {
            _userRepository = UserRepository;
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<AutoMapper.UserInfoProfile>();
            //    // cfg.CreateMap<DemmDto, Demm>();
            //    // cfg.CreateMap<UserInfoDto, Q_UserInfo>();
            //});
        }

        public List<DepartmentDto> GetList(int id = 0)
        {
            var list = _userRepository.GetAllList();
            var alist = Mapper.Map<List<DepartmentDto>>(list);
            Tree(alist, 0, new List<DepartmentDto>());
            if (id > 0)
            {
                alist = new List<DepartmentDto>();
                var aa = Mapper.Map<DepartmentDto>(_userRepository.GetAll().First(x => x.depId == id));
                alist.Add(aa);
            }
            return alist;
        }

        public bool Insert(DepartmentDto model)
        {
            try
            {
                var olModel = Mapper.Map<Q_Department>(model);
                var back = _userRepository.InsertAndGetId(olModel);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(DepartmentDto model)
        {
            var olmodel = _userRepository.GetAll().First(x => x.depId == model.depId);
            if (olmodel == null)
            {
                return false;
            }
            olmodel.depName = model.depName;
            olmodel.depIsDel = model.depIsDel;
            olmodel.depPid = model.depPid;
            olmodel.depRemark = model.depRemark;
            try
            {
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
            var olmodel = _userRepository.GetAll().First(x => x.depId == id);
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

        string xian = "----";
        public List<DepartmentDto> Tree(List<DepartmentDto> dto, int id, List<DepartmentDto> backTree)
        {

            foreach (var x in dto)
            {
                if (x.depPid == id)
                {

                    var back = dto.FirstOrDefault(p => p.depId == id);
                    x.depPName = back != null ? back.depName : "总公司";
                    backTree.Add(new DepartmentDto
                    {
                        Id = x.Id,
                        depPid = x.depPid,
                        depAddTime = x.depAddTime,
                        depIsDel = x.depIsDel,
                        depName = xian + x.depName,
                        depPName = x.depPName,
                        depRemark = x.depRemark,
                        depId = x.depId
                    });

                    xian = xian + "----";
                    Tree(dto, x.depId, backTree);
                }
            }
            if (xian.Length > 4)
            {
                xian = xian.Remove(0, 4);
            }
            return backTree;
        }

        public List<DepartmentDto> GetListTree(int id = 0)
        {
            var list = _userRepository.GetAllList();
            var alist = Mapper.Map<List<DepartmentDto>>(list);
            // alist.Insert(0, new DepartmentDto { Id = 0, depName = "总公司名称" });

            var backTree = Tree(alist, 0, new List<DepartmentDto>());
            backTree.Insert(0, new DepartmentDto { depId = 0, depName = "总公司名称" });
            return backTree;
        }
    }
}
