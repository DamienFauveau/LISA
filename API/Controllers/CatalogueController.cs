using LISA.DAL;
using LISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API.Controllers
{
    public class CatalogueController : ApiController
    {
        private Dal<Catalogue> catalogueDal = new Dal<Catalogue>();

        // GET: Catalogue
        public List<Catalogue> Get()
        {
            return catalogueDal.FindAll();
        }

        // GET: Catalogue/5
        public Catalogue Get(int id)
        {
            return catalogueDal.FindById(id);
        }

        // POST: Catalogue
        public void Post([FromBody]Catalogue catalogue)
        {
            catalogueDal.Creer(catalogue);
        }

        // PUT: Catalogue/5
        public void Put(int id, [FromBody]Catalogue catalogue)
        {
            if(id == catalogue.Id)
            {
                catalogueDal.Update(catalogue);
            }
        }

        // DELETE: Catalogue/5
        public void Delete(int id)
        {
            catalogueDal.Supprimer(catalogueDal.FindById(id));
        }
    }
}
