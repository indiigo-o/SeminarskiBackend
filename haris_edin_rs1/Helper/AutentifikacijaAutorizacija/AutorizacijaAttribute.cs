using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using haris_edin_rs1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FIT_Api_Examples.Helper.AutentifikacijaAutorizacija
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute()
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] {  };
        }
    }


    public class MyAuthorizeImpl : IActionFilter
    {
     
        private readonly bool _admin;
        private readonly bool _korisnici;
       

        public MyAuthorizeImpl( bool admin, bool korisnici)
        {
           
            _admin = admin;
            _korisnici = korisnici;
           
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.GetLoginInfo().isLogiran)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            KretanjePoSistemu.Save(filterContext.HttpContext);

            if (filterContext.HttpContext.GetLoginInfo().isPermisijaAdmin)
            {
                return;//ok - ima pravo pristupa
            }
           
            if (filterContext.HttpContext.GetLoginInfo().isPermisijaKorisnik && _korisnici)
            {
                return;//ok - ima pravo pristupa
            }
          

            //else nema pravo pristupa
            filterContext.Result = new UnauthorizedResult();
        }

    }
}
