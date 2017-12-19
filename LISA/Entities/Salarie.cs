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
    }
}
