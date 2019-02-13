using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Interfaces.Authentication;
using ScientificPublications.WebUI.Models.BindingModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ScientificPublications.WebUI.Filters
{
    public class AuthenticationFilter : IActionFilter
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IAuthenticationOptions _authenticationOptions;

        public AuthenticationFilter(ITokenGenerator tokenGenerator, IAuthenticationOptions authenticationOptions)
        {
            _tokenGenerator = tokenGenerator;
            _authenticationOptions = authenticationOptions;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var baseBm = context.ActionArguments.Values.OfType<BindingModel>().Single();

            try
            {
                var token = context.HttpContext.Request.Headers["Authorization"].ToString();
                var payloadJson = _tokenGenerator.Decode(token.Replace("Bearer ", ""), _authenticationOptions.SecretKey);
                var payloadDictonary = JsonConvert.DeserializeObject<Dictionary<string, string>>(payloadJson);

                baseBm.UserInfo = new UserInfo
                {
                    Authenticated = true,
                    Username = payloadDictonary[ClaimsIdentity.DefaultNameClaimType]
                };
            }
            catch
            {
                baseBm.UserInfo = new UserInfo();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
