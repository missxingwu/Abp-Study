using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace OA
{
    [DependsOn(typeof(AbpWebApiModule), typeof(OAApplicationModule))]
    public class OAWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(OAApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
