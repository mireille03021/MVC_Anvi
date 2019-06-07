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
    public class ColorsController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: Colors
        public ActionResult Index(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Colors.Count()); //傳入總筆數
            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Color> colors = db.Colors.OrderBy(x => x.ColorID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 7;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數
            return View("../BackSystem/ListAllColor", colors);
        }

        // GET: Colors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 7;    //Active Dashboard
            return View(color);
        }

        // GET: Colors/Create
        public ActionResult Create()
        {
            ViewData["SideActive"] = 7;    //Active Dashboard
            return View();
        }

        // POST: Colors/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColorID,ColorName")] Color color)
        {
            if (ModelState.IsValid)
            {
                db.Colors.Add(color);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["SideActive"] = 7;    //Active Dashboard
            return View(color);
        }

        // GET: Colors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 7;    //Active Dashboard
            return View(color);
        }

        // POST: Colors/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColorID,ColorName")] Color color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(color).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["SideActive"] = 7;    //Active Dashboard
            return View(color);
        }

        // GET: Colors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = db.Colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 7;    //Active Dashboard
            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Color color = db.Colors.Find(id);
            db.Colors.Remove(color);
            db.SaveChanges();
            ViewData["SideActive"] = 7;    //Active Dashboard
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
