using Abp.Web.Mvc.Views;

namespace OA.Web.Views
{
    public abstract class OAWebViewPageBase : OAWebViewPageBase<dynamic>
    {

    }

    public abstract class OAWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected OAWebViewPageBase()
        {
            LocalizationSourceName = OAConsts.LocalizationSourceName;
        }
    }
}