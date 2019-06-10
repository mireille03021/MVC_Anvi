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
    public class ShippersController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: Shippers
        public ActionResult Index(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Shippers.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Shipper> shippers = db.Shippers.OrderBy(x => x.ShipperID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 12;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數
            return View("../BackSystem/ListAllShipper", shippers);
        }

        // GET: Shippers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 12;    //Active Dashboard
            return View(shipper);
        }

        // GET: Shippers/Create
        public ActionResult Create()
        {
            ViewData["SideActive"] = 12;    //Active Dashboard
            return View();
        }

        // POST: Shippers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperID,ShippName,Phone")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
                ViewData["SideActive"] = 12;    //Active Dashboard
                return RedirectToAction("Index");
            }

            return View(shipper);
        }

        // GET: Shippers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 12;    //Active Dashboard
            return View(shipper);
        }

        // POST: Shippers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperID,ShippName,Phone")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["SideActive"] = 12;    //Active Dashboard
            return View(shipper);
        }

        // GET: Shippers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 12;    //Active Dashboard
            return View(shipper);
        }

        // POST: Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipper shipper = db.Shippers.Find(id);
            db.Shippers.Remove(shipper);
            db.SaveChanges();
            ViewData["SideActive"] = 12;    //Active Dashboard
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
