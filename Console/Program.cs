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
            Dal<Client> clientDal = new Dal<Client>();
            Client test = clientDal.findById(1);
            test.Email = "dsqdsqdsqd@hotmail.fr";
            clientDal.update();
        }
    }
}
