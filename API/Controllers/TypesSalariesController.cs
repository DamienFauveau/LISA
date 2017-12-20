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
    public class TypesSalariesController : ApiController
    {
        private Dal<TypeSalarie> TypeSalarieDal = new Dal<TypeSalarie>();

        // GET: TypesSalaries
        public List<TypeSalarie> GetTypesSalaries(string token)
        {
            return TypeSalarieDal.FindAll();
        }

        // GET: TypesSalaries/5
        [ResponseType(typeof(TypeSalarie))]
        public IHttpActionResult GetTypeSalarie(string token, int id)
        {
            TypeSalarie TypeSalarie = TypeSalarieDal.FindById(id);
            if (TypeSalarie == null)
            {
                return NotFound();
            }

            return Ok(TypeSalarie);
        }

        // PUT: TypesSalaries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeSalarie(string token, int id, TypeSalarie TypeSalarie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != TypeSalarie.Id)
            {
                return BadRequest();
            }

            TypeSalarieDal.Update(TypeSalarie);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: TypesSalaries
        [ResponseType(typeof(TypeSalarie))]
        public IHttpActionResult PostTypeSalarie(string token, TypeSalarie TypeSalarie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TypeSalarieDal.Creer(TypeSalarie);

            return CreatedAtRoute("DefaultApi", new { id = TypeSalarie.Id }, TypeSalarie);
        }

        // DELETE: TypesSalaries/5
        [ResponseType(typeof(TypeSalarie))]
        public IHttpActionResult DeleteTypeSalarie(string token, int id)
        {
            TypeSalarie TypeSalarie = TypeSalarieDal.FindById(id);
            if (TypeSalarie == null)
            {
                return NotFound();
            }

            TypeSalarieDal.Supprimer(TypeSalarie);

            return Ok(TypeSalarie);
        }
    }
}
