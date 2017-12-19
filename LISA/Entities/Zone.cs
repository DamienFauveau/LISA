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
    }
}
