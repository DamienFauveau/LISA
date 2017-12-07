using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    public class TypeSalarie
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

        /// <summary>
        /// Liste des salariés de ce type
        /// </summary>
        public virtual List<Salarie> Salaries { get; set; }
        #endregion
    }
}
