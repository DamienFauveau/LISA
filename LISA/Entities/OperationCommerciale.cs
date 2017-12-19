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

        #region Methods
        /// <summary>
        /// Calcul du HashCode de l'objet (ce qui le rend unique d'un point du vue métier)
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (Id != 0) ? Id.GetHashCode() : 0;
        }

        /// <summary>
        /// Surcharge de la méthode Equals afin que celle-ci se repose sur le calcul du HashCode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        /// <summary>
        /// Implémentation de la méthode de comparaison de 2 objets entre eux
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual int CompareTo(OperationCommerciale other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
