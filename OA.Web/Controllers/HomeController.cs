using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class HomeController : OAControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}