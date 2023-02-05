using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using NHP_CHETAS.Models;

namespace NHP_CHETAS.Filter
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly string _permission;
        public AuthorizeActionFilter(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string currentUserRole = Convert.ToString(context.HttpContext.Session.GetString("ListDams"));
            bool isAuthorized = CheckUserPermission(context.HttpContext.User, _permission, currentUserRole);
            if (!isAuthorized)
            {
                context.Result = new RedirectToRouteResult
                (
                    new RouteValueDictionary(new
                    {
                        action = "Index",
                        controller = "Error"
                    }));
            }
        }

        private bool CheckUserPermission(ClaimsPrincipal httpContextUser, string permission, string currentUserRole)
        {
            if (currentUserRole != null)
            {
                var objLstDamName = JsonConvert.DeserializeObject<List<string>>(currentUserRole);
                if (objLstDamName?.Count > 0)
                {
                    if (objLstDamName.Contains(permission?.Replace("_", " ")))
                    {
                        return true;
                    }
                    else if (permission == "Reports_Page")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
