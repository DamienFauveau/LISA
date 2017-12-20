using API.Attributes;
using LISA.DAL;
using LISA.Entities;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    [TokenVerification]
    public class CataloguesController : ApiController
    {
        private Dal<Catalogue> catalogueDal = new Dal<Catalogue>();

        // GET: Catalogues
        public List<Catalogue> GetCatalogues(string token)
        {
            return catalogueDal.FindAll();
        }

        // GET: Catalogues/5
        [ResponseType(typeof(Catalogue))]
        public IHttpActionResult GetCatalogue(string token, int id)
        {
            Catalogue Catalogue = catalogueDal.FindById(id);
            if (Catalogue == null)
            {
                return NotFound();
            }
            return Ok(Catalogue);
        }

        // PUT: Catalogues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatalogue(string token, int id, Catalogue Catalogue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Catalogue.Id)
            {
                return BadRequest();
            }
            catalogueDal.Update(Catalogue);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Catalogues
        [ResponseType(typeof(Catalogue))]
        public IHttpActionResult PostCatalogue(string token, Catalogue Catalogue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            catalogueDal.Creer(Catalogue);
            return CreatedAtRoute("DefaultApi", new { id = Catalogue.Id }, Catalogue);
        }

        // DELETE: Catalogues/5
        [ResponseType(typeof(Catalogue))]
        public IHttpActionResult DeleteCatalogue(string token, int id)
        {
            Catalogue Catalogue = catalogueDal.FindById(id);
            if (Catalogue == null)
            {
                return NotFound();
            }
            catalogueDal.Supprimer(Catalogue);
            return Ok(Catalogue);
        }
    }
}
