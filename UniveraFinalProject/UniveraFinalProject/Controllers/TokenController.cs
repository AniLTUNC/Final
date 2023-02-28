using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniveraFinalProject.Controllers
{
    public class TokenController : Controller
    {
        TokenManager _tokenManager;

        public TokenController(TokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public ActionResult GetToken()
        {
            var token = _tokenManager.CreateToken(new Token());

            return View(token);
        }
        [Authorize]
        public ActionResult SecureAction()
        {
            // Güvenli işlemler
            return View();
        }
    }
}