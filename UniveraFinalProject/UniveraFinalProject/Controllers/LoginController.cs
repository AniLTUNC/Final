using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace UniveraFinalProject.Controllers
{
    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EFUserDal());

       [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            UniveraFinalProjectContext c = new UniveraFinalProjectContext();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword );
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult UserLogin(User u)
        {
            UniveraFinalProjectContext c = new UniveraFinalProjectContext();
            var uuserinfo = c.Users.FirstOrDefault(x => x.UserName == u.UserName && x.Password == u.Password);
            if (uuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(uuserinfo.UserName, false);
                Session["UserName"] = uuserinfo.UserName;
                return RedirectToAction("UserProfile", "UserPanel");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        UniveraFinalProjectContext c = new UniveraFinalProjectContext();
        [HttpGet]
        public ActionResult AddUser()
        {
            // Veritabanından ülkeleri getirin
            var countries = c.Countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            // View'a aktarın
            ViewBag.Countries = countries;

            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            UserValidator validations = new UserValidator();
            ValidationResult results = validations.Validate(user);
            if (results.IsValid)
            {
                um.UserAdd(user);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}