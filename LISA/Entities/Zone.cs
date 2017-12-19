using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    public class Zone : IEntity
    {
        #region properties
        /// <summary>
        /// Identifiant de la zone
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type de zone
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Coordonnée d'abscisse de la zone
        /// </summary>
        public int CoordX { get; set; }

        /// <summary>
        /// Coordonnée d'ordonnée de la zone
        /// </summary>
        public int CoordY { get; set; }

        /// <summary>
        /// Largeur de la zone
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Hauteur de la zone
        /// </summary>
        public int Height { get; set; }
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
        public virtual int CompareTo(Zone other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
