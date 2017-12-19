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
<<<<<<< HEAD
            Dal<Client> clientDal = new Dal<Client>();
            Client test = clientDal.FindById(1);
            test.Email = "dsqdsqdsqd@hotmail.fr";
            clientDal.Update();
=======
            Dal<Catalogue> catalogueDal = new Dal<Catalogue>();
            Catalogue test = catalogueDal.FindById(1);
            Console.WriteLine(test.Width);
            Console.ReadKey(); 
            //test.Label = "Test update";
            //catalogueDal.Update(test);
>>>>>>> f88023c61996fd4b51041bb0db9d54c7eeb94077
        }
    }
}
