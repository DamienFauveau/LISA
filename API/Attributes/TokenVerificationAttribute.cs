using LISA.DAL;
using LISA.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class TokenVerificationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// Affecte ou obtient le nom du paramètre qui stocke le jeton d'authentification à l'API
        /// </summary>
        public string TokenParameterName { get; set; }

        private SalarieDal SalarieDal = new SalarieDal();

        public TokenVerificationAttribute() : this("token") { }

        public TokenVerificationAttribute(string tokenParameterName)
        {
            this.TokenParameterName = tokenParameterName;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            object token = actionContext.ActionArguments[TokenParameterName];

            if (token == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                message.ReasonPhrase = "La requête ne comporte aucun paramètre de type 'token'.";
                throw new HttpResponseException(message);
            }

            Salarie salarie = SalarieDal.FindByToken(token.ToString());

            if(salarie == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                message.ReasonPhrase = string.Format("Le jeton est invalide.");
                throw new HttpResponseException(message);
            }

            int comparaisonDateToken = DateTime.Compare(DateTime.Now, salarie.TokenExpirationDate);

            if(comparaisonDateToken > 0)
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                message.ReasonPhrase = string.Format("Le jeton n'est plus valide.");
                throw new HttpResponseException(message);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}