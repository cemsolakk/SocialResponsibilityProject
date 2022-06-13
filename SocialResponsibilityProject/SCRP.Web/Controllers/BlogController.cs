
using SCRP.Foundation.Entities;
using SCRP.Web.Models.Posts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SCRP.Web.Controllers
{
    public class BlogController : Controller
    {
        

        public ActionResult Index()
        {
            //var postList = _postBLL.GetList();

            //PostListViewModel postListViewModel = new PostListViewModel();

            //postListViewModel.Posts = postList.ToList();

            ////Blog Listeleme
            //return View(postListViewModel);
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
        //public ActionResult Detail(int blogid)
        //{
        //    //Blog Detay Sayfası
        //    return View();
        //}
    }
}