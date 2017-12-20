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
    public class PagesController : ApiController
    {
        private Dal<Page> PageDal = new Dal<Page>();

        // GET: Pages
        public List<Page> GetPages(string token)
        {
            return PageDal.FindAll();
        }

        // GET: Pages/5
        [ResponseType(typeof(Page))]
        public IHttpActionResult GetPage(string token, int id)
        {
            Page Page = PageDal.FindById(id);
            if (Page == null)
            {
                return NotFound();
            }

            return Ok(Page);
        }

        // PUT: Pages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPage(string token, int id, Page Page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Page.Id)
            {
                return BadRequest();
            }

            PageDal.Update(Page);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Pages
        [ResponseType(typeof(Page))]
        public IHttpActionResult PostPage(string token, Page Page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PageDal.Creer(Page);

            return CreatedAtRoute("DefaultApi", new { id = Page.Id }, Page);
        }

        // DELETE: Pages/5
        [ResponseType(typeof(Page))]
        public IHttpActionResult DeletePage(string token, int id)
        {
            Page Page = PageDal.FindById(id);
            if (Page == null)
            {
                return NotFound();
            }

            PageDal.Supprimer(Page);

            return Ok(Page);
        }
    }
}
