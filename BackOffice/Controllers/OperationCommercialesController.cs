using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LISA;
using LISA.Entities;
using BackOffice.Models;
using BackOffice.Attributes;

namespace BackOffice.Controllers
{
    [ConnexionVerification]
    public class OperationCommercialesController : Controller
    {
        private BddContext db = new BddContext();

        // GET: OperationCommerciales
        public ActionResult Index()
        {
            OperationCommercialeVM opComerciale = new OperationCommercialeVM();
            return View(Service.HttpClientService.Get<OperationCommercialeVM>(opComerciale, "http://localhost:53334/" + Session["token"] + "/OperationCommerciales"));
        }

        // GET: OperationCommerciales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationCommerciale operationCommerciale = db.OperationsCommerciales.Find(id);
            if (operationCommerciale == null)
            {
                return HttpNotFound();
            }
            return View(operationCommerciale);
        }

        // GET: OperationCommerciales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OperationCommerciales/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Title,StartDate,EndDate")] OperationCommerciale operationCommerciale)
        {
            if (ModelState.IsValid)
            {
                db.OperationsCommerciales.Add(operationCommerciale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operationCommerciale);
        }

        // GET: OperationCommerciales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationCommerciale operationCommerciale = db.OperationsCommerciales.Find(id);
            if (operationCommerciale == null)
            {
                return HttpNotFound();
            }
            return View(operationCommerciale);
        }

        // POST: OperationCommerciales/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Title,StartDate,EndDate")] OperationCommerciale operationCommerciale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operationCommerciale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operationCommerciale);
        }

        // GET: OperationCommerciales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationCommerciale operationCommerciale = db.OperationsCommerciales.Find(id);
            if (operationCommerciale == null)
            {
                return HttpNotFound();
            }
            return View(operationCommerciale);
        }

        // POST: OperationCommerciales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OperationCommerciale operationCommerciale = db.OperationsCommerciales.Find(id);
            db.OperationsCommerciales.Remove(operationCommerciale);
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
