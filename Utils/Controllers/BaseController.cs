using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils.Models.Shared;

namespace Utils.Controllers
{
    public class BaseController : Controller
    {
        [System.Web.Http.HttpGet]
        public ActionResult GetConfirmPartial(ConfirmModal data)
        {
            return View(data);
        }
    }
}