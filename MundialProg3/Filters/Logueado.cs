using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class Logueado : Attribute, IAuthorizationFilter
    {
        public string [] Rol { get; set; }

        public Logueado(params string [] rol)
        {
            Rol = rol;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("Rol") == null)
            {
                context.Result = new RedirectResult("~/Usuario/InicioSesion");
            }
            else
            {
                string rol = context.HttpContext.Session.GetString("Rol");
                if (!this.Rol.Contains(rol))
                {
                    context.Result = new RedirectResult("~/Usuario/InicioSesion");
                }
                //else
                //{
                //    if (rol.Equals("Admin"))
                //    {
                //        context.Result = new RedirectResult("~/Home/Index");
                //    }
                //    else
                //    {
                //        context.Result = new RedirectResult("~/Home/Index");
                //    }
                //}

            }
        }
    }
}
