using LISA.Entities;
using LISA.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LISA.DAL
{
    public class SalarieDal
    {
        private BddContext bdd;

        public SalarieDal()
        {
            bdd = new BddContext();
        }

        public List<Salarie> FindAll()
        {
            return bdd.Salaries.ToList();
        }

        public Salarie FindById(int id)
        {
            return bdd.Salaries.SingleOrDefault(salarie => salarie.Id == id);
        }

        public Salarie FindByEmail(string email)
        {
            return bdd.Salaries.SingleOrDefault(salarie => salarie.Email == email);
        }

        public Salarie FindByToken(string token)
        { 
            return bdd.Salaries.SingleOrDefault(salarie => salarie.Token == token);
        }

        public void Creer(Salarie salarie)
        {
            //string motDePasseEncode = EncodeMD5(salarie.Password);
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = EncodeMD5.GetMd5Hash(md5Hash, salarie.Password);
                salarie.Password = hash;
            }
            bdd.Salaries.Add(salarie);
            bdd.SaveChanges();
        }

        public void Supprimer(Salarie salarie)
        {
            bdd.Salaries.Remove(salarie);
            bdd.SaveChanges();
        }

        public void Update(Salarie salarie)
        {
            bdd.Entry(salarie).State = EntityState.Modified;
            bdd.SaveChanges();
        }

        public bool Connexion(string login, string motDePasse)
        {
            bool verification = false;
            Salarie salarie = bdd.Salaries.FirstOrDefault(obj => obj.Email == login);
            if (salarie != null)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    if (EncodeMD5.VerifyMd5Hash(md5Hash, motDePasse, salarie.Password))
                    {
                        verification = true;
                    }
                }
            }
            return verification;
        }
    }
}
