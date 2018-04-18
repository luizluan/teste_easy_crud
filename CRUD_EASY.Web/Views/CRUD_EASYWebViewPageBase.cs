using Abp.Web.Mvc.Views;

namespace CRUD_EASY.Web.Views
{
    public abstract class CRUD_EASYWebViewPageBase : CRUD_EASYWebViewPageBase<dynamic>
    {

    }

    public abstract class CRUD_EASYWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected CRUD_EASYWebViewPageBase()
        {
            LocalizationSourceName = CRUD_EASYConsts.LocalizationSourceName;
        }
    }
}