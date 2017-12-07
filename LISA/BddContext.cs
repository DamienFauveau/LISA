﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LISA.Entities;

namespace LISA
{
    public class BddContext : DbContext
    {
        public BddContext() : base("name=BddConnexionString")
        {

        }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Magasin> Magasins { get; set; }
        public DbSet<OperationCommerciale> OperationsCommerciales { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<TypeSalarie> TypesSalaries { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}
