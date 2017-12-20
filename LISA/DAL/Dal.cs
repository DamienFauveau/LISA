using LISA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.DAL
{
    public class Dal<T> where T : class, IEntity
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<T> FindAll()
        {
            return bdd.Set<T>().ToList<T>();
        }

        public T FindById(int id)
        {
            return bdd.Set<T>().SingleOrDefault(obj => obj.Id == id);
        }

        public void Creer(T obj)
        {
            bdd.Set<T>().Add(obj);
            bdd.SaveChanges();
        }

        public void Supprimer(T obj)
        {
            bdd.Set<T>().Remove(obj);
            bdd.SaveChanges();
        }

        public void Update(T obj)
        { 
            bdd.Entry(obj).State = EntityState.Modified;
            bdd.SaveChanges();
        }

    }
}