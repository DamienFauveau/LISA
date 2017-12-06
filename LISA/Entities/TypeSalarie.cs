using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    class TypeSalarie
    {
        #region properties
        /// <summary>
        /// Identifiant du type de salarié
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Libelle du type de salarié
        /// </summary>
        public string Libelle { get; set; }
        #endregion
    }
}
