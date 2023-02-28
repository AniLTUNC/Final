using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace UniveraFinalProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager( new EFCategoryDal());
       
       
        UniveraFinalProjectContext c = new UniveraFinalProjectContext();
        [Authorize]
        public ActionResult Index(string p)
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
            var values = from x in c.Categories select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.CategoryName.Contains(p));
            }
            return View(values.ToList());
        }
        [Authorize(Roles="B")]
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [Authorize(Roles = "B")]
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                cm.CategoryAdd(category);
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
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalues = cm.GetByID(id);
            cm.CategoryDelete(categoryvalues);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalues = cm.GetByID(id);
            return View(categoryvalues);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
        public ActionResult GetAllCategory(string p)
        {
            var values = from x in c.Categories select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.CategoryName.Contains(p));
            }
            return View(values.ToList());
        }
    }
}