using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    public class Catalogue : IEntity
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
        public string Label{ get; set; }

        /// <summary>
        /// Affecte ou obtient la largeur
        /// </summary>
        public float Witdh { get; set; }

        /// <summary>
        /// Affecte ou obtient la hauteur
        /// </summary>
        public float Height{ get; set; }

        /// <summary>
        /// Affecte ou obtient les pages
        /// </summary>
        public virtual List<Page> Pages { get; set; }

        /// <summary>
        /// Affecte ou obtient l'opération commerciale
        /// </summary>
        public virtual OperationCommerciale Op { get; set; }

        /// <summary>
        /// Affecte ou obtient les magasins
        /// </summary>
        public virtual List<Magasin> Magasins { get; set; }
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
        public virtual int CompareTo(Catalogue other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
