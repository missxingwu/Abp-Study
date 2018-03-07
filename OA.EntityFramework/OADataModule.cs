using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using OA.EntityFramework;

namespace OA
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(OACoreModule))]
    public class OADataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<OADbContext>(null);
        }
    }
}
