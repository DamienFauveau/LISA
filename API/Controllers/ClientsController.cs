using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using LISA.Entities;
using LISA.DAL;
using API.Attributes;

namespace API.Controllers
{
    [TokenVerification]
    public class ClientsController : ApiController
    {
        private Dal<Client> clientDal = new Dal<Client>();

        // GET: Clients
        public List<Client> GetClients(string token)
        {
            return clientDal.FindAll();
        }

        // GET: Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(string token, int id)
        {
            Client client = clientDal.FindById(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(string token, int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            clientDal.Update(client);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(string token, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            clientDal.Creer(client);

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        // DELETE: Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(string token, int id)
        {
            Client client = clientDal.FindById(id);
            if (client == null)
            {
                return NotFound();
            }

            clientDal.Supprimer(client);

            return Ok(client);
        }
    }
}