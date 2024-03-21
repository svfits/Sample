using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SF.DAL;

namespace SF.WebApi.BL.Atribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute(params TypeUser[] typeUsers) : Attribute, IAuthorizationFilter
{
    private readonly TypeUser[] _typeUsers = typeUsers;

    public void OnAuthorization(AuthorizationFilterContext filterContext)
    {
        var user = (User)filterContext.HttpContext.Items["LoggedInUser"];

        if (user == null)
        {
            filterContext.Result = new UnauthorizedResult();
            return;
        }

        if (!_typeUsers.Contains(user.TypeUser))
        {
            filterContext.Result = new UnauthorizedResult();
            return;
        }
    }
}
