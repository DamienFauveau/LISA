using API.Attributes;
using LISA.DAL;
using LISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    [TokenVerification]
    public class ProduitsController : ApiController
    {
        private Dal<Produit> ProduitDal = new Dal<Produit>();

        // GET: Produits
        public List<Produit> GetProduits(string token)
        {
            return ProduitDal.FindAll();
        }

        // GET: Produits/5
        [ResponseType(typeof(Produit))]
        public IHttpActionResult GetProduit(string token, int id)
        {
            Produit Produit = ProduitDal.FindById(id);
            if (Produit == null)
            {
                return NotFound();
            }

            return Ok(Produit);
        }

        // PUT: Produits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduit(string token, int id, Produit Produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Produit.Id)
            {
                return BadRequest();
            }

            ProduitDal.Update(Produit);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Produits
        [ResponseType(typeof(Produit))]
        public IHttpActionResult PostProduit(string token, Produit Produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProduitDal.Creer(Produit);

            return CreatedAtRoute("DefaultApi", new { id = Produit.Id }, Produit);
        }

        // DELETE: Produits/5
        [ResponseType(typeof(Produit))]
        public IHttpActionResult DeleteProduit(string token, int id)
        {
            Produit Produit = ProduitDal.FindById(id);
            if (Produit == null)
            {
                return NotFound();
            }

            ProduitDal.Supprimer(Produit);

            return Ok(Produit);
        }
    }
}
