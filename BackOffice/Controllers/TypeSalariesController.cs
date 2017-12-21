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

namespace BackOffice.Controllers
{
    public class TypeSalariesController : Controller
    {
        private BddContext db = new BddContext();

        // GET: TypeSalaries
        public ActionResult Index()
        {
            TypeSalarieVM typeSalarie = new TypeSalarieVM();
            return View(Service.HttpClientService<TypeSalarieVM>.Get(typeSalarie, "http://localhost:53334/23824c437c1a275f5f6fcf40667faf01/TypeSalaries"));
        }

        // GET: TypeSalaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeSalarie typeSalarie = db.TypesSalaries.Find(id);
            if (typeSalarie == null)
            {
                return HttpNotFound();
            }
            return View(typeSalarie);
        }

        // GET: TypeSalaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeSalaries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle")] TypeSalarie typeSalarie)
        {
            if (ModelState.IsValid)
            {
                db.TypesSalaries.Add(typeSalarie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeSalarie);
        }

        // GET: TypeSalaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeSalarie typeSalarie = db.TypesSalaries.Find(id);
            if (typeSalarie == null)
            {
                return HttpNotFound();
            }
            return View(typeSalarie);
        }

        // POST: TypeSalaries/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle")] TypeSalarie typeSalarie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeSalarie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeSalarie);
        }

        // GET: TypeSalaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeSalarie typeSalarie = db.TypesSalaries.Find(id);
            if (typeSalarie == null)
            {
                return HttpNotFound();
            }
            return View(typeSalarie);
        }

        // POST: TypeSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeSalarie typeSalarie = db.TypesSalaries.Find(id);
            db.TypesSalaries.Remove(typeSalarie);
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
