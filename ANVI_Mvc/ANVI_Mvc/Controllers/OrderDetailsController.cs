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
using static ANVI_Mvc.Helpers.ConstantData;

namespace ANVI_Mvc.Controllers
{
    public class OrderDetailsController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: OrderDetails
        public ActionResult Index()
        {
            List<OrderDetail> orderDetails = db.OrderDetails.OrderBy(x => x.OrderID).ToList();
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
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID");
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

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderDetail.OrderID);
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", orderDetail.PDID);
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
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderDetail.OrderID);
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", orderDetail.PDID);
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
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderDetail.OrderID);
            ViewBag.PDID = new SelectList(db.ProductDetails, "PDID", "PDID", orderDetail.PDID);
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
