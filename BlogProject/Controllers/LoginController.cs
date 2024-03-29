﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            Context context = new Context();
            var userInfos = context.Authors.FirstOrDefault(x => x.AuthorMail == author.AuthorMail && x.Password == author.Password);

            if (userInfos != null)
            {
                FormsAuthentication.SetAuthCookie(userInfos.AuthorMail, false);
                Session["AuthorMail"] = userInfos.AuthorMail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            Context context = new Context();
            var adminInfos = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (adminInfos != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfos.UserName, false);
                Session["UserName"] = adminInfos.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }


    }
}