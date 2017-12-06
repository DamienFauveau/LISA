using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    class Catalogue
    {
        #region Properties
        /// <summary>
        /// Obtient l'id
        /// </summary>
        public int Id { get; }

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
        public string Label{ get; set; }

        /// <summary>
        /// Affecte ou obtient la largeur
        /// </summary>
        public float witdh { get; set; }

        /// <summary>
        /// Affecte ou obtient la hauteur
        /// </summary>
        public float height{ get; set; }

        /// <summary>
        /// Affecte ou obtient les pages
        /// </summary>
        public List<Page> pages { get; set; }

        /// <summary>
        /// Affecte ou obtient l'opération commerciale
        /// </summary>
        public OperationCommerciale op { get; set; }

        /// <summary>
        /// Affecte ou obtient les magasins
        /// </summary>
        public List<Magasin> Magasins { get; set; }
        #endregion
    }
}
