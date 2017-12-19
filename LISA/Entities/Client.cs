using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    public class Client : IEntity
    {
        #region properties
        /// <summary>
        /// Identifiant associé au client
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du client
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prenom du client
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Email du client
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Ville du client
        /// </summary>
        public string Ville { get; set; }

        /// <summary>
        /// Code postal de la ville du client
        /// </summary>
        public string CodePostal { get; set; }

        /// <summary>
        /// Liste des magasins auquel le client est abonné
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
        public virtual int CompareTo(Client other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
