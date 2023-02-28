using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniveraFinalProject.Controllers
{
 
    public class UserPanelController : Controller
    {
        public ActionResult UserProfile()
        {
           return View();
        }
    }
}