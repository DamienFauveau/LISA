using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    public class Salarie : IEntity
    {
        #region properties

        /// <summary>
        /// Id associé au salarié
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du salarié
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du salarié
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Email du salarié
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Numéro de téléphone du salarié
        /// </summary>
        public int Telephone { get; set; }

        /// <summary>
        /// Mot de passe du salarié
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Type du salarié
        /// </summary>
        public virtual TypeSalarie TypeSalarie { get; set; }
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
        public virtual int CompareTo(Salarie other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
