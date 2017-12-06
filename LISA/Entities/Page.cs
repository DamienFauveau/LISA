using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    class Page
    {
        #region properties
        /// <summary>
        /// Identifiant de la page
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Numéro de la page dans le catalogue
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Liste des produits présents sur la page
        /// </summary>
        public List<Produit> Products { get; set; }
        #endregion
    }
}
