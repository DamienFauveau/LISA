using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOffice.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Le nom d'utilisateur est erroné")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Le mot de passe est erroné")]
        public string Password { get; set; }
    }
}