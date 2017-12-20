using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Models
{
    public class TypeSalarieVM
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
        public virtual List<SalarieVM> Salaries { get; set; }
        #endregion
    }
}