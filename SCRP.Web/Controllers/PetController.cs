using System.Web.Mvc;

namespace SCRP.Web.Controllers
{
    public class PetController : Controller
    {
        public ActionResult SearchPage()
        {
            //arama sayfası index
            return View();
        }

        [HttpPost]
        public ActionResult SearchPage(int[] parameters)
        {
            //arama sayfası post 
            return View();
        }

        public ActionResult Detail()
        {
            // kayıp evcil hayvan detay sayfası
            return View();
        }
    }
}