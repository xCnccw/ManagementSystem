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
    public class TenantController : Controller
    {
        private ManagementProjectEntities db = new ManagementProjectEntities();

        // GET: Tenant
        public ActionResult Index()
        {
            return View(db.w_tenant.ToList());
        }

        // GET: Tenant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_tenant w_tenant = db.w_tenant.Find(id);
            if (w_tenant == null)
            {
                return HttpNotFound();
            }
            return View(w_tenant);
        }

        // GET: Tenant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tenant/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,phone,roomnumber,rent,IdCardNumber")] w_tenant w_tenant)
        {
            if (ModelState.IsValid)
            {
                db.w_tenant.Add(w_tenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(w_tenant);
        }

        // GET: Tenant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_tenant w_tenant = db.w_tenant.Find(id);
            if (w_tenant == null)
            {
                return HttpNotFound();
            }
            return View(w_tenant);
        }

        // POST: Tenant/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,phone,roomnumber,rent,isPayed,IdCardNumber")] w_tenant w_tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_tenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_tenant);
        }

        // GET: Tenant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_tenant w_tenant = db.w_tenant.Find(id);
            if (w_tenant == null)
            {
                return HttpNotFound();
            }
            return View(w_tenant);
        }

        // POST: Tenant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            w_tenant w_tenant = db.w_tenant.Find(id);
            db.w_tenant.Remove(w_tenant);
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

    public ActionResult ByThemselves()
    {
      int id = (int)Session["id"];
      //if (id == null)
      //{
      //  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //}
      w_tenant w_tenant = db.w_tenant.Find(id);
      if (w_tenant == null)
      {
        return HttpNotFound();
      }
      return View(w_tenant);
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult ByThemselves([Bind(Include = "id,username,phone,roomnumber,rent,isPayed,IdCardNumber")] w_tenant w_tenant)
    {
      if (ModelState.IsValid)
      {
        db.Entry(w_tenant).State = EntityState.Modified;
        db.SaveChanges();
        return Content("<script>alert('保存成功！');window.location.href='/Admin/Index'; </script>");
      }
      return View(w_tenant);
    }
  }
}

