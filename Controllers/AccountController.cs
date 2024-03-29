﻿using OST_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OST_Inventory.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string btnSubmit, BaseAccount baseAccount)
        {  

            string LoginMsg = "";
            if (btnSubmit == "Login")
            {
                bool verifyStatus=baseAccount.VerifyLogin();
                if (verifyStatus)
                {
                    Session["User"] = baseAccount.UserName;
                    Session["Role"] = baseAccount.Role;
                    LoginMsg = "Login Success";

                    //return RedirectToAction("Dashboard", "Home");
                } 
                else
                {
                    LoginMsg = "Failed, Username/Password not match";
                }
            }
            else if(btnSubmit == "Forget Password")
            {
                return RedirectToAction("forget", "Account");
            }
            ViewBag.LoginMsg = LoginMsg;
            return View();
        } 
        //public ActionResult ForgetPassword(string btnSubmit)
        //{
        //    if (btnSubmit == "Forget Password")
        //    {
        //        return RedirectToAction("forget", "Account");
        //    }
        //    return RedirectToAction("Login", "Account"); 
        //}
        public ActionResult forget()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session["User"] = null; 
            return RedirectToAction("Login", "Account");
        }
    }
}