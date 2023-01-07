using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;

namespace ManagementSystem.Controllers
{
    public class SystemController : Controller
    {
        private ManagementProjectEntities db = new ManagementProjectEntities();

        // GET: System
        public ActionResult Index(String type="")
        {
            IEnumerable<w_system_params> list = db.w_system_params;
      if (!string.IsNullOrEmpty(type))
      {
        list = list.Where(p => p.type == type);
      }
            return View(list.ToList());
        }

        // GET: System/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_system_params w_system_params = db.w_system_params.Find(id);
            if (w_system_params == null)
            {
                return HttpNotFound();
            }
            return View(w_system_params);
        }

        // GET: System/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: System/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name,type")] w_system_params w_system_params)
        {
                db.w_system_params.Add(w_system_params);
                int result=db.SaveChanges();
                if (result > 0)
                {
                   return Content("<script>alert('保存成功！');window.location.href='/System/Index'; </script>");
                  //return RedirectToAction("Index");
                }
                else
                {
                  ViewBag.notice = "保存失败！请重试！";
                }
                return View(w_system_params);
        }

        // GET: System/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_system_params w_system_params = db.w_system_params.Find(id);
            if (w_system_params == null)
            {
                return HttpNotFound();
            }
            return View(w_system_params);
        }

        // POST: System/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name,type")] w_system_params w_system_params)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_system_params).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_system_params);
        }


        // POST: System/Delete/5
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            w_system_params w_system_params = db.w_system_params.Find(id);
            db.w_system_params.Remove(w_system_params);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
