using Abp.Web.Mvc.Controllers;

namespace OA.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class OAControllerBase : AbpController
    {
        protected OAControllerBase()
        {
            LocalizationSourceName = OAConsts.LocalizationSourceName;
        }
    }
}