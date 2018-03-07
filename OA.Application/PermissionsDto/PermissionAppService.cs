using Abp.Domain.Repositories;
using AutoMapper;
using OA.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.PermissionsDto
{
    public class PermissionAppService : OAAppServiceBase, IPermissionAppService
    {
        private readonly IRepository<Q_Permission> _permRepository;
        private readonly IRepository<Q_PermissionButton> _permButtRepository;

        public PermissionAppService(IRepository<Q_Permission> permRepository, IRepository<Q_PermissionButton> permButtRepository)
        {
            _permRepository = permRepository;
            _permButtRepository = permButtRepository;
        }
        public PermissionDto Get(int id)
        {

            return Mapper.Map<PermissionDto>(_permRepository.GetAll().First(x => x.pid == id));


        }
        public List<PermissionDto> GetAll()
        {
            var back = Mapper.Map<List<PermissionDto>>(_permRepository.GetAllList());
            return back;
        }
        public List<PermissionDto> GetAllTree()
        {
            var back = Mapper.Map<List<PermissionDto>>(_permRepository.GetAllList());
            List<PermissionDto> tree = new List<PermissionDto>();
            if (back.Count > 0)
            {

                Tree(back, 0, tree);
            }

            return tree;
        }
        public bool Insert(PermissionDto model)
        {
            try
            {
                var oModel = Mapper.Map<Q_Permission>(model);
                _permRepository.Insert(oModel);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Update(PermissionDto model)
        {

            try
            {
                var oModel = _permRepository.GetAll().First(x => x.pid == model.pid);
                oModel.pActionName = model.pActionName;
                oModel.pAreaName = model.pAreaName;
                oModel.pControllerName = model.pControllerName;
                oModel.pFormMethod = model.pFormMethod;
                oModel.pIco = model.pIco;
                oModel.pIsLink = model.pIsLink;
                oModel.pIsShow = model.pIsShow;
                oModel.pLinkUrl = model.pLinkUrl;
                oModel.pName = model.pName;
                oModel.pOperationType = model.pOperationType;
                oModel.pOrder = model.pOrder;
                oModel.pParent = model.pParent;
                oModel.pRemark = model.pRemark;
                _permRepository.Update(oModel);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var oModel = _permRepository.FirstOrDefault(x => x.pid == id);
                //先删外键关联项
                if (_permButtRepository.Count(x => x.pbPId == id) > 0)
                {
                    _permButtRepository.Delete(x => x.pbPId == id);
                }

                _permRepository.Delete(oModel);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        string xian = "----";
        public void Tree(List<PermissionDto> dto, int id, List<PermissionDto> tree)
        {
            //, List<PermissionDto> backTree
            foreach (var x in dto)
            {
                if (x.pParent == id)
                {

                    var back = dto.FirstOrDefault(p => p.pid == id);
                    // x.depPName = back != null ? back.depName : "总公司";
                    x.pName = xian + x.pName;
                    tree.Add(new PermissionDto
                    {
                        Id = x.Id,
                        pName = x.pName,
                        pid = x.pid,

                    });

                    xian = xian + "----";
                    Tree(dto, x.pid, tree);
                }
            }
            if (xian.Length > 4)
            {
                xian = xian.Remove(0, 4);
            }
            // return dto;
        }

        public bool InsertPerButton(List<PermissionButtonDto> listDto)
        {
            try
            {
                var uORrId = listDto.First().UorRId;
                if (_permButtRepository.Count(u => u.UorRId == uORrId) > 0)
                {
                    _permButtRepository.Delete(u => u.UorRId == uORrId);
                }
                var list = Mapper.Map<List<Q_PermissionButton>>(listDto);
                foreach (var item in list)
                {
                    item.Q_Permission = _permRepository.FirstOrDefault(x => x.pid == item.pbPId);
                    _permButtRepository.Insert(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<PermissionButtonDto> GetPerBtn(int id, int state)
        {
            var list = Mapper.Map<List<PermissionDto>>(_permRepository.GetAll().Where(x => x.pIsDel == false).ToList());
            var backList = Mapper.Map<List<PermissionButtonDto>>(_permButtRepository.GetAllList(x => x.UorRId == id && x.pbUorRStatr == state));

            var addss = Mapper.Map<List<PermissionButtonDto>>(list);
            if (list.Count > 0 && backList.Count > 0)
            {
                foreach (var item in backList)
                {
                    var aa = addss.First(x => x.pbPId == item.pbPId);
                    item.pbPName = aa.pbPName;
                    item.pbIsDel = true;
                    addss.Remove(aa);
                }
            }
            backList.AddRange(addss);            
            return backList;
        }
    }
}
