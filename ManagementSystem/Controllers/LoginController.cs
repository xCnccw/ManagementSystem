using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagementSystem.Models;
using System.Web.Mvc;

namespace ManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private ManagementProjectEntities db=new ManagementProjectEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //实现登录功能
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            if (string.IsNullOrEmpty(username))
            {
              ViewBag.notice = "用户名不能为空！";
              return View();
      }
            if (string.IsNullOrEmpty(password))
            {
              ViewBag.notice = "密码不能为空！";
              return View();
            }

            w_admin admin = db.w_admin.FirstOrDefault(p => p.username == username);
            if(admin==null)
            {
              ViewBag.notice = "用户不存在！";
            }else if(admin.pass!=password)
            {
              ViewBag.notice = "密码不正确！";
            }
            else
            {
        Session["username"] = admin.username;
        Session["nickname"] = admin.nickname;
        Session["power"] = admin.power;
        Session["id"] = admin.id;
        return Redirect("/Admin/index");
            }
            return View();
           
        }

    public ActionResult logout()
    {
      Session["username"] = null;
      Session["nickname"] = null;
      Session["power"] = null;
      Session["id"] = null;
      return Redirect("/Login/index");
    }
  }
}
