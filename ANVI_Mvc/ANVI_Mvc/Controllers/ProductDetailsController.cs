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
    public class ProductDetailsController : Controller
    {
        private AnviModel db = new AnviModel();
        private Helper hp = new Helper();

        // GET: ProductDetails
        public ActionResult Index(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.ProductDetails.Count()); //傳入總筆數
            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<ProductDetail> productDetils = db.ProductDetails.OrderBy(x => x.PDID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = (int)SideIndex.ProductDetail;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數
            return View("../BackSystem/ListAllProductDetail", productDetils);
        }

        // GET: ProductDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = db.ProductDetails.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = (int)SideIndex.ProductDetail;
            return View(productDetail);
        }

        // GET: ProductDetails/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeContext");
            ViewData["SideActive"] = (int)SideIndex.ProductDetail;
            return View();
        }

        // POST: ProductDetails/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=(int)SideIndex.ProductDetail17598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PDID,ProductID,Stock,SizeID,ColorID")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                db.ProductDetails.Add(productDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productDetail.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", productDetail.ProductID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeContext", productDetail.SizeID);
            ViewData["SideActive"] = (int)SideIndex.ProductDetail;
            return View(productDetail);
        }

        // GET: ProductDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = db.ProductDetails.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productDetail.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", productDetail.ProductID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeContext", productDetail.SizeID);
            ViewData["SideActive"] = (int)SideIndex.ProductDetail;
            return View(productDetail);
        }

        // POST: ProductDetails/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=(int)SideIndex.ProductDetail17598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PDID,ProductID,Stock,SizeID,ColorID")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productDetail.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", productDetail.ProductID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeContext", productDetail.SizeID);
            ViewData["SideActive"] = (int)SideIndex.ProductDetail;
            return View(productDetail);
        }

        // GET: ProductDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = db.ProductDetails.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewData["SideActive"] = (int)SideIndex.ProductDetail;
            return View(productDetail);
        }

        // POST: ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProductDetail productDetail = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(productDetail);
            db.SaveChanges();
            ViewData["SideActive"] = (int)SideIndex.ProductDetail;
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
