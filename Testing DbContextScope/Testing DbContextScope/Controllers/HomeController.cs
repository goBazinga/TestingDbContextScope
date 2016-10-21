﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingDbContextScope.Data;

namespace Testing_DbContextScope.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ProductDbContext();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}