using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    public class OperationCommerciale : IEntity
    {
        #region Properties
        /// <summary>
        /// Obtient l'id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Affecte ou obtient le titre
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Affecte ou obtient la date de début
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Affecte ou obtient la date de fin
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Affecte ou obtient les catalogues
        /// </summary>
        public virtual List<Catalogue> Catalogues { get; set; }
        #endregion
    }
}
