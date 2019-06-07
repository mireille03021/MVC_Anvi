using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ANVI_Mvc.Helpers;
using ANVI_Mvc.Models;

namespace ANVI_Mvc.Controllers
{
    public class ImagesController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: Images
        public ActionResult Index(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Images.Count()); //傳入總筆數
            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Image> images = db.Images.OrderBy(x => x.ImgID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 5;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數
            return View("../BackSystem/ListAllImage", images);
        }

        // GET: Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 5;    //Active Dashboard
            return View(image);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID");
            ViewData["SideActive"] = 5;    //Active Dashboard
            return View();
        }

        // POST: Images/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImgID,PDID,ImgName")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", image.PDID);
            ViewData["SideActive"] = 5;    //Active Dashboard
            return View(image);
        }

        // GET: Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", image.PDID);
            ViewData["SideActive"] = 5;    //Active Dashboard
            return View(image);
        }

        // POST: Images/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImgID,PDID,ImgName")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", image.PDID);
            ViewData["SideActive"] = 5;    //Active Dashboard
            return View(image);
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 5;    //Active Dashboard
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            ViewData["SideActive"] = 5;    //Active Dashboard
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
