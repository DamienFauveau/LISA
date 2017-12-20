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
    public class OperationsCommercialesController : ApiController
    {
        private Dal<OperationCommerciale> OperationCommercialeDal = new Dal<OperationCommerciale>();

        // GET: OperationsCommerciales
        public List<OperationCommerciale> GetOperationsCommerciales(string token)
        {
            return OperationCommercialeDal.FindAll();
        }

        // GET: OperationsCommerciales/5
        [ResponseType(typeof(OperationCommerciale))]
        public IHttpActionResult GetOperationCommerciale(string token, int id)
        {
            OperationCommerciale OperationCommerciale = OperationCommercialeDal.FindById(id);
            if (OperationCommerciale == null)
            {
                return NotFound();
            }

            return Ok(OperationCommerciale);
        }

        // PUT: OperationsCommerciales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOperationCommerciale(string token, int id, OperationCommerciale OperationCommerciale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != OperationCommerciale.Id)
            {
                return BadRequest();
            }

            OperationCommercialeDal.Update(OperationCommerciale);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: OperationsCommerciales
        [ResponseType(typeof(OperationCommerciale))]
        public IHttpActionResult PostOperationCommerciale(string token, OperationCommerciale OperationCommerciale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OperationCommercialeDal.Creer(OperationCommerciale);

            return CreatedAtRoute("DefaultApi", new { id = OperationCommerciale.Id }, OperationCommerciale);
        }

        // DELETE: OperationsCommerciales/5
        [ResponseType(typeof(OperationCommerciale))]
        public IHttpActionResult DeleteOperationCommerciale(string token, int id)
        {
            OperationCommerciale OperationCommerciale = OperationCommercialeDal.FindById(id);
            if (OperationCommerciale == null)
            {
                return NotFound();
            }

            OperationCommercialeDal.Supprimer(OperationCommerciale);

            return Ok(OperationCommerciale);
        }
    }
}
