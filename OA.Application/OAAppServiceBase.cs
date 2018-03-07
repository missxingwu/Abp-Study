using Abp.Application.Services;
using AutoMapper;

namespace OA
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class OAAppServiceBase : ApplicationService
    {
        protected OAAppServiceBase()
        {
            LocalizationSourceName = OAConsts.LocalizationSourceName;
            //
            //new MapperConfiguration(cfg =>
            // {
            //     cfg.AddProfile<AutoMapper.UserInfoProfile>();
            //});
            #region 0.0 AutoMapper 测试注册
            // var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfoDto, Q_UserInfo>());
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<AutoMapper.UserInfoProfile>();
            //    // cfg.CreateMap<DemmDto, Demm>();
            //    // cfg.CreateMap<UserInfoDto, Q_UserInfo>();
            //});
            // IMapper mapper = new Mapper(config);
            //var mapper = config.CreateMapper();
            //// CreateMap<Q_UserInfo, UserInfoDto>();
            //var aa = mapper.Map<Q_UserInfo>(model); 
            #endregion
        }
    }
}