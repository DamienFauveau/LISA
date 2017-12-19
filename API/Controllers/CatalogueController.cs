<<<<<<< HEAD
﻿using System;
=======
﻿using LISA.DAL;
using LISA.Entities;
using System;
>>>>>>> f88023c61996fd4b51041bb0db9d54c7eeb94077
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

<<<<<<< HEAD
=======

>>>>>>> f88023c61996fd4b51041bb0db9d54c7eeb94077
namespace API.Controllers
{
    public class CatalogueController : ApiController
    {
<<<<<<< HEAD
        // GET: api/Catalogue
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Catalogue/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Catalogue
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Catalogue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Catalogue/5
        public void Delete(int id)
        {
=======
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
>>>>>>> f88023c61996fd4b51041bb0db9d54c7eeb94077
        }
    }
}
