using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    public class Produit : IComparable<Produit>
    {
        #region Properties
        /// <summary>
        /// Obtient l'id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Affecte ou obtient le label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Affecte ou obtient la description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Affecte ou obtient la categorie
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Affecte ou obtient le prix
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Affecte ou obtient la réduction en pourcent
        /// </summary>
        public int ReductionPercent { get; set; }

        /// <summary>
        /// Affecte ou obtient l'avantage en pourcent
        /// </summary>
        public int AvantagePercent { get; set; }

        /// <summary>
        /// Affecte ou obtient l'écotaxe
        /// </summary>
        public int Ecotaxe { get; set; }

        /// <summary>
        /// Affecte ou obtient l'image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Affecte ou obtient le picto
        /// </summary>
        public string Picto { get; set; }

        /// <summary>
        /// Affecte ou obtient l'origine
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Affecte ou obtient la mention
        /// </summary>
        public string Mention { get; set; }

        /// <summary>
        /// Affecte ou obtient le packaging
        /// </summary>
        public string Packaging { get; set; }

        /// <summary>
        /// Affecte ou obtient le lower price
        /// </summary>
        public int Lowerprice { get; set; }

        /// <summary>
        /// Affecte ou obtient la couleur
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Affecte ou obtient la réduction en euro
        /// </summary>
        public int ReductionEuro { get; set; }

        /// <summary>
        /// Affecte ou obtient l'avantage en euro
        /// </summary>
        public int AvantageEuro { get; set; }

        /// <summary>
        /// Affecte ou obtient les zones
        /// </summary>
        public virtual List<Zone> Zones { get; set; }

        /// <summary>
        /// Affecte ou obtient les pages
        /// </summary>
        public virtual List<Page> Pages { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Calcul du HashCode de l'objet (ce qui le rend unique d'un point du vue métier)
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (Code != 0) ? Code.GetHashCode() : 0;
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
        public virtual int CompareTo(Produit other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
