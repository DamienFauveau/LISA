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
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BackOffice.Models;
using System.Web.Script.Serialization;
using System.Web.Configuration;
using BackOffice.Attributes;

namespace BackOffice.Controllers
{
    public class CataloguesController : Controller
    {
        private BddContext db = new BddContext();

        public List<CatalogueVM> GetCatalogueAsync()
        {
            HttpClient client = new HttpClient();
            List<CatalogueVM> catalogues = new List<CatalogueVM>();

            HttpResponseMessage response = client.GetAsync("http://localhost:53334/23824c437c1a275f5f6fcf40667faf01/Catalogues", HttpCompletionOption.ResponseHeadersRead).Result;
            
            if(response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                catalogues = JsonConvert.DeserializeObject<List<CatalogueVM>>(responseBody);
            }
            
            return catalogues;
        }

        // GET: Catalogues
        [ConnexionVerification]
        public ActionResult Index()
        {
            return View(GetCatalogueAsync());
        }

        // GET: Catalogues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue catalogue = db.Catalogues.Find(id);
            if (catalogue == null)
            {
                return HttpNotFound();
            }
            return View(catalogue);
        }

        // GET: Catalogues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogues/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle,Type,Label,Width,Height")] Catalogue catalogue)
        {
            if (ModelState.IsValid)
            {
                db.Catalogues.Add(catalogue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalogue);
        }

        // GET: Catalogues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue catalogue = db.Catalogues.Find(id);
            if (catalogue == null)
            {
                return HttpNotFound();
            }
            return View(catalogue);
        }

        // POST: Catalogues/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle,Type,Label,Width,Height")] Catalogue catalogue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalogue);
        }

        // GET: Catalogues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogue catalogue = db.Catalogues.Find(id);
            if (catalogue == null)
            {
                return HttpNotFound();
            }
            return View(catalogue);
        }

        // POST: Catalogues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalogue catalogue = db.Catalogues.Find(id);
            db.Catalogues.Remove(catalogue);
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
