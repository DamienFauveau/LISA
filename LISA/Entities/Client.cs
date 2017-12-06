using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    class Client
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
        #endregion
    }
}
