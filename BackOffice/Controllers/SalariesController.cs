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
    public class SalariesController : Controller
    {
        private BddContext db = new BddContext();

        // GET: Salaries
        public ActionResult Index()
        {
            SalarieVM salarie = new SalarieVM();
            return View(Service.HttpClientService.Get<SalarieVM>(salarie, "http://localhost:53334/" + Session["token"] + "/Salaries"));
        }

        // GET: Salaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salarie salarie = db.Salaries.Find(id);
            if (salarie == null)
            {
                return HttpNotFound();
            }
            return View(salarie);
        }

        // GET: Salaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salaries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Email,Telephone,Password")] Salarie salarie)
        {
            if (ModelState.IsValid)
            {
                db.Salaries.Add(salarie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salarie);
        }

        // GET: Salaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salarie salarie = db.Salaries.Find(id);
            if (salarie == null)
            {
                return HttpNotFound();
            }
            return View(salarie);
        }

        // POST: Salaries/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Email,Telephone,Password")] Salarie salarie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salarie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salarie);
        }

        // GET: Salaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salarie salarie = db.Salaries.Find(id);
            if (salarie == null)
            {
                return HttpNotFound();
            }
            return View(salarie);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salarie salarie = db.Salaries.Find(id);
            db.Salaries.Remove(salarie);
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
