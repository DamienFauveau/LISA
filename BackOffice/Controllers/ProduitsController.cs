﻿using System;
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
    public class ProduitsController : Controller
    {
        private BddContext db = new BddContext();

        // GET: Produits
        public ActionResult Index()
        {
            ProduitVM produit = new ProduitVM();
            return View(Service.HttpClientService.Get<ProduitVM>(produit, "http://localhost:53334/" + Session["token"] + "/Produits"));
        }

        // GET: Produits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: Produits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produits/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Label,Description,Category,Price,ReductionPercent,AvantagePercent,Ecotaxe,Image,Picto,Origin,Mention,Packaging,Lowerprice,Color,ReductionEuro,AvantageEuro")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Produits.Add(produit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produit);
        }

        // GET: Produits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Label,Description,Category,Price,ReductionPercent,AvantagePercent,Ecotaxe,Image,Picto,Origin,Mention,Packaging,Lowerprice,Color,ReductionEuro,AvantageEuro")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produit);
        }

        // GET: Produits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produit produit = db.Produits.Find(id);
            db.Produits.Remove(produit);
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
