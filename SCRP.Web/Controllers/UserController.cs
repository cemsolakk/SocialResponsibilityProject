
using SCRP.DAL.EF;
using SCRP.Foundation.Entities;
using SCRP.Web.Models.User;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SCRP.Web.Controllers
{
    public class UserController : Controller
    {
        public DatabaseContext GetDatabaseContext()
        {
            DatabaseContext context = new DatabaseContext();
            context.Configuration.LazyLoadingEnabled = false;
            return context;
        }

        public ActionResult Register()
        {
            UserEditViewModel viewModel = new UserEditViewModel();
            viewModel.Member = new Member();
            return View(viewModel);
        }

       

        [HttpPost]
        public ActionResult Register(UserEditViewModel userEditViewModel)
        {
            Member member = userEditViewModel.Member;
            var context = GetDatabaseContext();
            member.CreatedOn = DateTime.Now;
            if (context.Members.Any(x=> x.Email == member.Email))
            {
                TempData["Error"] = "Bu email adresi zaten kullanılıyor";
                return View();
            }
            if (String.IsNullOrEmpty(member.Password) || String.IsNullOrEmpty(member.Email) || String.IsNullOrEmpty(member.FirstName)
                || String.IsNullOrEmpty(member.LastName) || String.IsNullOrEmpty(member.Phone))
            {
                TempData["Error"] = "Bu email adresi zaten kullanılıyor";
                return View();
            }
            context.Members.Add(member);
            context.SaveChanges();
            TempData["CssClassName"] = "success";
            TempData["Message"] = "Registration Successful.";

            return RedirectToAction("Login");
        }


        public ActionResult Login()
        {
            // Login Form
            return View();
        }

        [HttpPost]
        public ActionResult LoginPost(string password, string email)
        {
            DatabaseContext context = GetDatabaseContext();
            var loggedUser = context.Members.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (loggedUser != null)
            {
                Session["ID"] = loggedUser.Id;
                Session["Email"] = loggedUser.Email;
                Session["FullName"] = $"{loggedUser.FirstName} {loggedUser.LastName}";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["CssClassName"] = "danger";
                TempData["Message"] = "Email or Password is wrong";
                return RedirectToAction("Login","Home");
            }
        }

        //[HttpPost]
        //public ActionResult Login(UserEditViewModel userEditViewModel)
        //{
        //    if (Session["Id"] != null)
        //    {
        //        var userId = int.Parse(Session["Id"].ToString());
        //        Member member = _memberBLL.GetById(userId);
        //        if (member != null)
        //        {
        //            return RedirectToAction("MyAdvertisements", "Member");
        //        }
        //    }

        //    var email = userEditViewModel.Member.Email;
        //    var pass = userEditViewModel.Member.Password;

        //    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass))
        //    {
        //        var currentMember = _memberBLL.GetList().FirstOrDefault(member => member.Email == email && member.Password == pass);

        //        if (currentMember != null)
        //        {
        //            Session["ID"] = currentMember.Id;
        //            Session["Email"] = currentMember.Email;
        //            Session["FullName"] = $"{currentMember.FirstName} {currentMember.LastName}";
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            TempData["CssClassName"] = "danger";
        //            TempData["Message"] = "Email or Password is wrong";
        //        }
        //    }
        //    return View();
        //}

        public ActionResult Logout()
        {
            Session.Clear();
            // Login Form
            return RedirectToAction("Login", "User");
        }
    }
}