using System.Reflection;
using Abp.Modules;

namespace OA
{
    public class OACoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
