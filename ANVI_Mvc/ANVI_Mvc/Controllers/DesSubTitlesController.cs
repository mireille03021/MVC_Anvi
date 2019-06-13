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
    public class DesSubTitlesController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: DesSubTitles
        public ActionResult Index()
        {
            List<DesSubTitle> desSubTitles = db.DesSubTitles.OrderBy(x => x.DSTID).ToList();
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
            return View(desSubTitle);
        }

        // GET: DesSubTitles/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: DesSubTitles/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=3175(int)SideIndex.DesSubTitle8。
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
            return View(desSubTitle);
        }

        // POST: DesSubTitles/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=3175(int)SideIndex.DesSubTitle8。
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
