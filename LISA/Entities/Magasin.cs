using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    class Magasin
    {
        #region properties
        /// <summary>
        /// Identifiant du magasin
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ville du magasin
        /// </summary>
        public string Ville { get; set; }

        /// <summary>
        /// Code postal de la ville du magasin
        /// </summary>
        public string CodePostal { get; set; }
        
        /// <summary>
        /// Liste des clients enregistrés pour ce magasin
        /// </summary>
        public List<Client> Clients { get; set; }

        /// <summary>
        /// Liste des clients enregistrés pour ce magasin
        /// </summary>
        public List<Catalogue> Catalogues { get; set; }
        #endregion
    }
}
