using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class PrivacyNTermsController : Controller
    {
        [Route("about/privacy")]
        public IActionResult IndexPrivacy()
        {
            return View();
        }
        [Route("about/privacy")]
        public IActionResult IndexTerms()
        {
            return View();
        }
    }
}
