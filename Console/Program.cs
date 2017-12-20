using LISA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISA.DAL;
using LISA.Entities;

namespace ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool connexion = false;
            do
            {
                SalarieDal dal = new SalarieDal();
                Console.WriteLine("Mot de passe: ");
                string motDePasse = Console.ReadLine();
                connexion = dal.Connexion("dylan.alizon@gmail.com", motDePasse);
                Console.WriteLine(connexion);
            } while (connexion == false);
        }
    }
}
