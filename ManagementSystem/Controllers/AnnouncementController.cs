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
    public class AnnouncementController : Controller
    {
        private ManagementProjectEntities db = new ManagementProjectEntities();

        // GET: Announcement
        public ActionResult Index()
        {
            w_announcement info= db.w_announcement.FirstOrDefault();
            return View(db.w_announcement);
        }

        // GET: Announcement/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_announcement w_announcement = db.w_announcement.Find(id);
            if (w_announcement == null)
            {
                return HttpNotFound();
            }
            return View(w_announcement);
        }

        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Content,CreateDate,People,id")] w_announcement w_announcement)
        {

                db.w_announcement.Add(w_announcement);
      int result = db.SaveChanges();
      if (result > 0)
      {
        return Content("<script>alert('保存成功！');window.location.href='/Admin/Index'; </script>");
      }
      else
      {
        ViewBag.notice = "保存失败！请重试！";
      }
      return View(w_announcement);
        }

        // GET: Announcement/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_announcement w_announcement = db.w_announcement.Find(id);
            if (w_announcement == null)
            {
                return HttpNotFound();
            }
            return View(w_announcement);
        }

        // POST: Announcement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Title,Content,CreateDate,People,id")] w_announcement w_announcement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_announcement);
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_announcement w_announcement = db.w_announcement.Find(id);
            if (w_announcement == null)
            {
                return HttpNotFound();
            }
            return View(w_announcement);
        }

        // POST: Announcement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            w_announcement w_announcement = db.w_announcement.Find(id);
            db.w_announcement.Remove(w_announcement);
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
