using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    class Produit
    {
        #region Properties
        public int Id { get; }

        public int Code { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public float Price { get; set; }

        public int ReductionPercent { get; set; }

        public int AvantagePercent { get; set; }

        public int Ecotaxe { get; set; }

        public string Image { get; set; }

        public string Picto { get; set; }

        public string Origin { get; set; }

        public string Mention { get; set; }

        public string Packaging { get; set; }

        public int Lowerprice { get; set; }

        public string Color { get; set; }

        public int ReductionEuro { get; set; }

        public int AvantageEuro { get; set; }

        public IList Zones { get; set; }
        #endregion
    }
}
