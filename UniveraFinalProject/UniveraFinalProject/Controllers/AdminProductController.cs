using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace UniveraFinalProject.Controllers
{
    public class AdminProductController : Controller
    {
        ProductManager pm = new ProductManager( new EFProductDal());
        CategoryManager cm = new CategoryManager( new EFCategoryDal());

        [Authorize]
        public ActionResult Index()
        {
            var productvalues = pm.GetList();
            return View(productvalues);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct( Product product)
        {
            ProductValidator validations = new ProductValidator();
            ValidationResult results = validations.Validate(product);  
            if (results.IsValid)
            {
                pm.ProductAdd(product);
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
        public ActionResult DeleteProduct(int id)
        {
            var productvalues = pm.GetByID(id);
            pm.DeleteProduct(productvalues);
            return RedirectToAction("Index");           
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            var productvalues = pm.GetByID(id);
            return View(productvalues);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            pm.UpdaterProduct(product);
            return RedirectToAction("Index");
        }

        UniveraFinalProjectContext c = new UniveraFinalProjectContext();
        public ActionResult GetAllProduct(string p)
        {
            var values = from x in c.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.ProductName.Contains(p));
            }
            return View(values.ToList());
        }
    }
}