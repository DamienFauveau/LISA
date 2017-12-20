using API.Attributes;
using API.DTO;
using LISA.DAL;
using LISA.Entities;
using LISA.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    public class SalariesController : ApiController
    {
        private SalarieDal SalarieDal = new SalarieDal();

        // GET: Salaries
        [TokenVerification]
        public List<Salarie> GetSalaries(string token)
        {
            return SalarieDal.FindAll();
        }

        // GET: Salaries/5
        [ResponseType(typeof(Salarie))]
        [TokenVerification]
        public IHttpActionResult GetSalarie(string token, int id)
        {
            Salarie salarie = SalarieDal.FindById(id);
            if (salarie == null)
            {
                return NotFound();
            }

            return Ok(salarie);
        }

        // PUT: Salaries/5
        [ResponseType(typeof(void))]
        [TokenVerification]
        public IHttpActionResult PutSalarie(string token, int id, Salarie salarie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salarie.Id)
            {
                return BadRequest();
            }

            SalarieDal.Update(salarie);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Salaries
        [ResponseType(typeof(Salarie))]
        [TokenVerification]
        public IHttpActionResult PostSalarie(string token, Salarie salarie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SalarieDal.Creer(salarie);

            return CreatedAtRoute("DefaultApi", new { id = salarie.Id }, salarie);
        }

        // DELETE: Salaries/5
        [ResponseType(typeof(Salarie))]
        [TokenVerification]
        public IHttpActionResult DeleteSalarie(string token, int id)
        {
            Salarie salarie = SalarieDal.FindById(id);
            if (salarie == null)
            {
                return NotFound();
            }

            SalarieDal.Supprimer(salarie);

            return Ok(salarie);
        }

        [HttpPost]
        [Route("Salaries/Connexion")]
        public IHttpActionResult ConnexionSalarie(LoginDTO connexion)
        {
            if (SalarieDal.Connexion(connexion.Login, connexion.Password))
            {
                DateTime datetime = DateTime.Now;
                string datetimeString = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", datetime);
                Salarie salarie = SalarieDal.FindByEmail(connexion.Login);
                string token = salarie.Email + datetimeString + salarie.Password;
                string encodedToken;
                using (MD5 md5Hash = MD5.Create())
                {
                    encodedToken = EncodeMD5.GetMd5Hash(md5Hash, token);
                }
                TokenDTO tokenDTO = new TokenDTO() { token = encodedToken };
                salarie.Token = tokenDTO.token;
                salarie.TokenExpirationDate = datetime.AddDays(1);
                SalarieDal.Update(salarie);
                return Ok(tokenDTO);
            }
            else
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
        }
        

        [HttpGet]
        [Route("{token}/Salaries/Deconnexion")]
        [TokenVerification]
        public IHttpActionResult DeconnexionSalarie(string token)
        {
            Salarie salarie = SalarieDal.FindByToken(token);
            if(salarie != null)
            {
                salarie.Token = null;
                SalarieDal.Update(salarie);
                return Ok();
            }
            return StatusCode(HttpStatusCode.NotFound);
        }
    }
}
