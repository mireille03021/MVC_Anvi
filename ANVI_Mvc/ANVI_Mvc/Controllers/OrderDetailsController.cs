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
    public class OrderDetailsController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: OrderDetails
        public ActionResult Index(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.OrderDetails.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<OrderDetail> orderDetails = db.OrderDetails.OrderBy(x => x.OrderID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 11;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數
            return View("../BackSystem/ListAllOrderDetail", orderDetails);
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int orderid, string pdid)
        {
            if (pdid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.First(x => x.OrderID == orderid && x.PDID == pdid);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 11;    //Active Dashboard
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "UserID");
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID");
            ViewData["SideActive"] = 11;    //Active Dashboard
            return View();
        }

        // POST: OrderDetails/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PDID,OrderID,Price,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "UserID", orderDetail.OrderID);
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", orderDetail.PDID);
            ViewData["SideActive"] = 11;    //Active Dashboard
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int orderid, string pdid)
        {
            if (pdid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.First(x => x.OrderID == orderid && x.PDID == pdid);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "UserID", orderDetail.OrderID);
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", orderDetail.PDID);
            ViewData["SideActive"] = 11;    //Active Dashboard
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PDID,OrderID,Price,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "UserID", orderDetail.OrderID);
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", orderDetail.PDID);
            ViewData["SideActive"] = 11;    //Active Dashboard
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int orderid, string pdid)
        {
            if (pdid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.First(x => x.OrderID == orderid && x.PDID == pdid);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = 11;    //Active Dashboard
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int orderid, string pdid)
        {
            OrderDetail orderDetail = db.OrderDetails.First(x => x.OrderID == orderid && x.PDID == pdid);
            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();
            ViewData["SideActive"] = 11;    //Active Dashboard
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
