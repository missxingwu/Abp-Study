using System.Reflection;
using Abp.Modules;
using OA.AutoMapper;
using Abp.AutoMapper;
using AutoMapper;
using OA.UserDto;
using OA.Entites;
using Abp.Hangfire.Configuration;
using Hangfire;

namespace OA
{
    // [DependsOn(typeof(OACoreModule), typeof(AbpAutoMapperModule))]
    public class OAApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapper.UserInfoProfile>();
            });
        }
        /// <summary>
        /// 审计日志 用法 控制器 [Audited]  方法名 [DisableAuditing]
        /// </summary>
        public override void PreInitialize()
        {
            // 可以在模块的PreInitialize方法中使用Configuration.Auditing属性。审计是默认开启的
            // 这儿是审计配置属性的列表：

            // IsEnabled: 用于完全开启或关闭审计系统。默认为true。
            // IsEnabledForAnonymousUsers: 如果此值为true,那么没有登录到系统的用户的审计日志也会保存。默认为false。
            // MvcControllers: 用于为ASP.NET MVC控制器配置审计。
            // IsEnabled: 用于为MVC控制器开启或关闭审计。默认为true
            // IsEnabledForChildActions:用于为子MVC action开启或关闭审计。默认为false。
            // Selectors: 用于选择其他的类保存审计日志。
            // 可以看到，对于MVC控制器的审计是单独配置的，因为它用到了不同的技术。

            // Selectors是选择其他的类型来保存审计日志的谓词列表。一个选择器有一个唯一的名字和一个谓词。这个列表中唯一的默认选择器用于选择应用服务类。它是如下定义的：

            // Configuration.Auditing.Selectors.Add(
            //    new NamedTypeSelector(
            //        "Abp.ApplicationServices",
            //        type => typeof(IApplicationService).IsAssignableFrom(type)
            //    )
            // );
            //ABP后台服务 - 集成Hangfire
            //Configuration.BackgroundJobs.UseHangfire(configuration =>
            //{
            //    configuration.GlobalConfiguration.UseSqlServerStorage("Default");
            //});

            Configuration.Auditing.IsEnabled = false;
        }

    }
}
