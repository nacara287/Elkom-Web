using And.ElkomMuhasebe.Core.Model;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.ElkomMuhasebe.UI.WEB.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            if (Session["AdminLoginUser"] == null) { 
                return Redirect("/Admin/AdminLogin");
            }
            else { 
            return View();
            }
        }
        public ActionResult UpdateData()
        {
            var config = new And.ElkomMuhasebe.Core.Model.Migrations.ConfigurationFirma();
            FirmaBaseDB dba = new FirmaBaseDB();
            AndDB db = new AndDB();
            var userlist = db.userFirmas.ToList();
            foreach (UserFirma firma in userlist) { 
            config.ManualSeed(dba, @"Host=185.131.49.20;Database=" + firma.DatabaseName + ";Username=postgres;Password=onjbQOfcK088!yyo");
            }
            return View();
           
        }
    }
}