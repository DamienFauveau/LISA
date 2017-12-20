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
            Dal<Catalogue> catalogueDal = new Dal<Catalogue>();
            Catalogue test = catalogueDal.FindById(1);
            Console.WriteLine(test.Width);
            Console.ReadKey(); 
        }
    }
}
