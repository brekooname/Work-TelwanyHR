using System;

using HR.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HR.Web.Helper
{
    public class Authorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userId = context.HttpContext.Request.Cookies[AppConstant.Cookies.userId];
            int id = 0;
            int.TryParse(userId, out id);

            if (id == 0)
            {
                context.HttpContext.Response.Cookies.Delete(AppConstant.Cookies.userId);


                context.Result = new RedirectResult("/Account/Login");
            }

        }
    }
}
