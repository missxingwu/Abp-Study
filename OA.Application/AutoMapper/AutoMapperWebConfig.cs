using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.AutoMapper
{
    public static class AutoMapperWebConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserInfoProfile>();
                // cfg.AddProfile<TerminalDeviceProfile>();
            });           
            Mapper.AssertConfigurationIsValid();//验证所有的映射配置是否都正常

            //new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<AutoMapper.UserInfoProfile>();
            //    // cfg.CreateMap<DemmDto, Demm>();
            //    // cfg.CreateMap<UserInfoDto, Q_UserInfo>();
            //});
        }
    }
}
