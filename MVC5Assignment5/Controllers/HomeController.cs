﻿using Assignment4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Assignment4.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext context = new MyDbContext();
        public ActionResult Index()
        {
            return View(context.Accounts);
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
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateAccount(Account a)
        {
            /*
            if (a.AccountNumber < 0)
            {
                ModelState.AddModelError("AccountNumber", "Account number cannot be negative");
}
            if (string.IsNullOrEmpty(a.Name))
            {
                ModelState.AddModelError("Name", "Account holder's name is required");
            }
            if ((a.CurrentBalance >= 1 && a.CurrentBalance < 500) ||
                        a.CurrentBalance < 0)
            {
                ModelState.AddModelError("CurrentBalance", "Minimum balance must be atleast 500");
            }
            */

            if (ModelState.IsValid)
            {
                context.Accounts.Add(a);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create");

        }
        public ActionResult Edit(int? accno)
        {
            var account_to_edit = (from a in context.Accounts
                                   where a.AccountNumber == accno
                                   select a).SingleOrDefault();
            return View(account_to_edit);
        }
        public ActionResult EditAccount(Account a)
        {
            context.Entry<Account>(a).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? accno)
        {
            var account_to_delete = (from a in context.Accounts
                                     where a.AccountNumber == accno
                                     select a).SingleOrDefault();
            context.Entry<Account>(account_to_delete).State =
                    System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GetNews(string category)
        {
            return PartialView(null, category);
        }



    }
}