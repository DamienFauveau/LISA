using LISA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using(BddContext context = new BddContext())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
}
