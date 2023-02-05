using Microsoft.AspNetCore.Mvc;

namespace NHP_CHETAS.Filter
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(string permission)
            : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}
