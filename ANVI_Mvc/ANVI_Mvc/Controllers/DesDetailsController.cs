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
    public class DesDetailsController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: DesDetails
        public ActionResult Index()
        {
            List<DesDetail> desDetails = db.DesDetails.OrderBy(x => x.DDID).ToList();
            return View("../BackSystem/ListAllDesDetail", desDetails);
        }

        // GET: DesDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesDetail desDetail = db.DesDetails.Find(id);
            if (desDetail == null)
            {
                return HttpNotFound();
            }
            return View(desDetail);
        }

        // GET: DesDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: DesDetails/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=31759(int)SideIndex.DesDetail。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DDID,ProductID,Detail")] DesDetail desDetail)
        {
            if (ModelState.IsValid)
            {
                db.DesDetails.Add(desDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", desDetail.ProductID);
            return View(desDetail);
        }

        // GET: DesDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesDetail desDetail = db.DesDetails.Find(id);
            if (desDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", desDetail.ProductID);
            return View(desDetail);
        }

        // POST: DesDetails/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=31759(int)SideIndex.DesDetail。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DDID,ProductID,Detail")] DesDetail desDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", desDetail.ProductID);
            return View(desDetail);
        }

        // GET: DesDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesDetail desDetail = db.DesDetails.Find(id);
            if (desDetail == null)
            {
                return HttpNotFound();
            }
            return View(desDetail);
        }

        // POST: DesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesDetail desDetail = db.DesDetails.Find(id);
            db.DesDetails.Remove(desDetail);
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
