using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMvcApp.Models;

namespace MyFirstMvcApp.Controllers
{
    public class DataTableDemoController : Controller
    {
        //
        // GET: /DataTableDemo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = 97,
                iTotalDisplayRecords = 3,
                aaData = new string[,]{    {"1","a1","a2","a3"},
                                              {"2","b1","b2","b3"},
                                              {"3","c1","c2","c3"} }
            },
                                                              JsonRequestBehavior.AllowGet);
        }

    }
}
