using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using And.ElkomMuhasebe.Core.Model;
using System.Web.Mvc;
using System.Web.Routing;
namespace And.ElkomMuhasebe.UI.WEB.Areas.Admin
{
    public class AdminControllerBase : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var IsLogin = false;
            if (requestContext.HttpContext.Session["AdminLoginUser"] == null)
            {
                requestContext.HttpContext.Response.Redirect("/Admin/AdminLogin");

            }
            else
            {
                base.Initialize(requestContext);
            }

        }
    }
}