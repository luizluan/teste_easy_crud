using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CRUD_EASY.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : CRUD_EASYControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}