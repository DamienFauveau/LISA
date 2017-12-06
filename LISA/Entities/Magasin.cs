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
        /// Code attribué au magasin
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Nom de la chaine de magasin
        /// </summary>
        public string Marque { get; set; }

        /// <summary>
        /// Ville du magasin
        /// </summary>
        public string Ville { get; set; }

        /// <summary>
        /// Code postal de la ville du magasin
        /// </summary>
        public int CodePostal { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Obtient le hashcode de l'objet
        /// </summary>
        public override int GetHashCode()
        {
            return !string.IsNullOrEmpty(Code) ? Code.GetHashCode() : 0;
        }
        #endregion
    }
}
