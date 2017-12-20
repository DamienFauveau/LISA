using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

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
        [Index(IsUnique = true)]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Numéro de téléphone du salarié
        /// </summary>
        public int Telephone { get; set; }

        /// <summary>
        /// Mot de passe du salarié
        /// </summary>
        [Required]
        [IgnoreDataMember]
        public string Password { get; set; }

        /// <summary>
        /// Type du salarié
        /// </summary>
        public virtual TypeSalarie TypeSalarie { get; set; }

        /// <summary>
        /// Token authentification
        /// </summary>
        [IgnoreDataMember]
        public string Token { get; set; }

        /// <summary>
        /// Date expiration du token
        /// </summary>
        [IgnoreDataMember]
        [Column("Token_Expiration_Date")]
        public DateTime TokenExpirationDate { get; set; }
        #endregion
    }
}
