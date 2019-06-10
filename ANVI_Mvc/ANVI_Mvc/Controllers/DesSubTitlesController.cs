﻿using System;
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
    public class DesSubTitlesController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: DesSubTitles
        public ActionResult Index(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.DesSubTitles.Count()); //傳入總筆數
            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<DesSubTitle> desSubTitles = db.DesSubTitles.OrderBy(x => x.DSTID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 9;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View("../BackSystem/ListAllDesSubTitle", desSubTitles);
        }

        // GET: DesSubTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesSubTitle desSubTitle = db.DesSubTitles.Find(id);
            if (desSubTitle == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 9;    //Active Dashboard
            return View(desSubTitle);
        }

        // GET: DesSubTitles/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewData["SideActive"] = 9;    //Active Dashboard
            return View();
        }

        // POST: DesSubTitles/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DSTID,ProductID,SubTitle")] DesSubTitle desSubTitle)
        {
            if (ModelState.IsValid)
            {
                db.DesSubTitles.Add(desSubTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", desSubTitle.ProductID);
            ViewData["SideActive"] = 9;    //Active Dashboard
            return View(desSubTitle);
        }

        // GET: DesSubTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesSubTitle desSubTitle = db.DesSubTitles.Find(id);
            if (desSubTitle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", desSubTitle.ProductID);
            ViewData["SideActive"] = 9;    //Active Dashboard
            return View(desSubTitle);
        }

        // POST: DesSubTitles/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DSTID,ProductID,SubTitle")] DesSubTitle desSubTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desSubTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", desSubTitle.ProductID);
            ViewData["SideActive"] = 9;    //Active Dashboard
            return View(desSubTitle);
        }

        // GET: DesSubTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesSubTitle desSubTitle = db.DesSubTitles.Find(id);
            if (desSubTitle == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 9;    //Active Dashboard
            return View(desSubTitle);
        }

        // POST: DesSubTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesSubTitle desSubTitle = db.DesSubTitles.Find(id);
            db.DesSubTitles.Remove(desSubTitle);
            db.SaveChanges();
            ViewData["SideActive"] = 9;    //Active Dashboard
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
