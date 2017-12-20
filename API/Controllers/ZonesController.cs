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
    public class ZonesController : ApiController
    {
        private Dal<Zone> ZoneDal = new Dal<Zone>();

        // GET: Zones
        public List<Zone> GetZones(string token)
        {
            return ZoneDal.FindAll();
        }

        // GET: Zones/5
        [ResponseType(typeof(Zone))]
        public IHttpActionResult GetZone(string token, int id)
        {
            Zone Zone = ZoneDal.FindById(id);
            if (Zone == null)
            {
                return NotFound();
            }

            return Ok(Zone);
        }

        // PUT: Zones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZone(string token, int id, Zone Zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Zone.Id)
            {
                return BadRequest();
            }

            ZoneDal.Update(Zone);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Zones
        [ResponseType(typeof(Zone))]
        public IHttpActionResult PostZone(string token, Zone Zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ZoneDal.Creer(Zone);

            return CreatedAtRoute("DefaultApi", new { id = Zone.Id }, Zone);
        }

        // DELETE: Zones/5
        [ResponseType(typeof(Zone))]
        public IHttpActionResult DeleteZone(string token, int id)
        {
            Zone Zone = ZoneDal.FindById(id);
            if (Zone == null)
            {
                return NotFound();
            }

            ZoneDal.Supprimer(Zone);

            return Ok(Zone);
        }
    }
}
