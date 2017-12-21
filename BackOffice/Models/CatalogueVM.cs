using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Models
{
    public class CatalogueVM
    {
        #region Properties
        /// <summary>
        /// Obtient l'id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le libelle
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Affecte ou obtient le type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Affecte ou obtient le label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Affecte ou obtient la largeur
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Affecte ou obtient la hauteur
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Affecte ou obtient les pages
        /// </summary>
        public virtual List<PageVM> Pages { get; set; }

        /// <summary>
        /// Affecte ou obtient l'opération commerciale
        /// </summary>
        public virtual OperationCommercialeVM Op { get; set; }

        /// <summary>
        /// Affecte ou obtient les magasins
        /// </summary>
        public virtual List<MagasinVM> Magasins { get; set; }
        #endregion
    }
}