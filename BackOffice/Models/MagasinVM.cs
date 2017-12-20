using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Models
{
    public class MagasinVM
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
        public virtual List<ClientVM> Clients { get; set; }

        /// <summary>
        /// Liste des clients enregistrés pour ce magasin
        /// </summary>
        public virtual List<CatalogueVM> Catalogues { get; set; }
        #endregion
    }
}