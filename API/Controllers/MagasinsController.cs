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
    public class MagasinsController : ApiController
    {
        private Dal<Magasin> MagasinDal = new Dal<Magasin>();

        // GET: Magasins
        public List<Magasin> GetMagasins(string token)
        {
            return MagasinDal.FindAll();
        }

        // GET: Magasins/5
        [ResponseType(typeof(Magasin))]
        public IHttpActionResult GetMagasin(string token, int id)
        {
            Magasin Magasin = MagasinDal.FindById(id);
            if (Magasin == null)
            {
                return NotFound();
            }

            return Ok(Magasin);
        }

        // PUT: Magasins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMagasin(string token, int id, Magasin Magasin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Magasin.Id)
            {
                return BadRequest();
            }

            MagasinDal.Update(Magasin);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Magasins
        [ResponseType(typeof(Magasin))]
        public IHttpActionResult PostMagasin(string token, Magasin Magasin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MagasinDal.Creer(Magasin);

            return CreatedAtRoute("DefaultApi", new { id = Magasin.Id }, Magasin);
        }

        // DELETE: Magasins/5
        [ResponseType(typeof(Magasin))]
        public IHttpActionResult DeleteMagasin(string token, int id)
        {
            Magasin Magasin = MagasinDal.FindById(id);
            if (Magasin == null)
            {
                return NotFound();
            }

            MagasinDal.Supprimer(Magasin);

            return Ok(Magasin);
        }
    }
}
