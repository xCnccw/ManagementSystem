using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;
namespace ManagementSystem.Controllers
{
    public class AdminController : Controller
    {
    private ManagementProjectEntities db = new ManagementProjectEntities();
    // GET: Admin
    public ActionResult Index()
    {
      if (Session["nickname"] == null)
      {
        return Redirect("/Login/index");
      }
      w_announcement announcement = db.w_announcement.OrderByDescending(e => e.id).FirstOrDefault();//取最新的通知，先倒序再取第一个（linq转sql问题）
      //w_room_info info = db.w_room_info.FirstOrDefault();
      return View(announcement);
    }
    //
    public ActionResult RoomIndex()
    {
      w_room_info info = db.w_room_info.FirstOrDefault();
      return View(info);
    }

    public ActionResult AddRoom()
    {
      return View();
    }
    [HttpPost]
    public ActionResult AddRoom(w_room_info room)
    {
      ViewBag.notice = "";
      db.w_room_info.Add(room);
      int result = db.SaveChanges();
      if (result > 0)
      {
        return Content("<script>alert('保存成功');window.location.href='/Admin/RoomIndex';<script>");
      }
      else
      {
        ViewBag.notice = "保存失败！请重试！";
      }
      return View();
    }

    public ActionResult UpdateRoom()
    {
      w_room_info info = db.w_room_info.FirstOrDefault();
      if (info == null)
      {
        return Content("<script>alert('未找到需要修改的信息');window.location.href='/Admin/AddRoom'; </script>");
      }
      return View(info);
    }

    [HttpPost]
    public ActionResult UpdateRoom(w_room_info info)
    {
      db.Entry(info).State = System.Data.Entity.EntityState.Modified;
      if (db.SaveChanges() > 0)
      {
        return Content("<script>alert('保存成功！');window.location.href='/Admin/RoomIndex'; </script>");
      }
      else
      {
        ViewBag.notice = "编辑小区信息失败！请重试";
      }
      return View();
    }
  }
}
