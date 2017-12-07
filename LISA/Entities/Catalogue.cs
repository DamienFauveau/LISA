﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISA.Entities
{
    public class Catalogue
    {
        #region Properties
        /// <summary>
        /// Obtient l'id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Affecte ou obtient le libelle
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Affecte ou obtient le type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Affecte ou obtient le label
        /// </summary>
        public string Label{ get; set; }

        /// <summary>
        /// Affecte ou obtient la largeur
        /// </summary>
        public float Witdh { get; set; }

        /// <summary>
        /// Affecte ou obtient la hauteur
        /// </summary>
        public float Height{ get; set; }

        /// <summary>
        /// Affecte ou obtient les pages
        /// </summary>
<<<<<<< HEAD
        public List<Page> Pages { get; set; }
=======
        public virtual List<Page> pages { get; set; }
>>>>>>> 658afbda13dd9d6d945cc22959e3b90f47562a7d

        /// <summary>
        /// Affecte ou obtient l'opération commerciale
        /// </summary>
        public OperationCommerciale Op { get; set; }

        /// <summary>
        /// Affecte ou obtient les magasins
        /// </summary>
        public virtual List<Magasin> Magasins { get; set; }
        #endregion
    }
}
