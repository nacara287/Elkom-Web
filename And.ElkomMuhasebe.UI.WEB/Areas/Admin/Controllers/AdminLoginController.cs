using And.ElkomMuhasebe.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.ElkomMuhasebe.UI.WEB.Areas.Admin
{
    public class AdminLoginController : Controller
    {

        AndDB db = new AndDB();
        // GET: /Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string mail,string password)
        {
           var data = db.Users.Where(x => x.mail == mail && x.password == password&& x.IsActive == true && x.IsAdmin == true).ToList();
            if (data.Count == 1)
            {
                //doğru giriş
                Session["AdminLoginUser"] = data.FirstOrDefault();
                return Redirect("/Admin/Default");
            }
            else
            {
                //yanlış giriş
                return View();
            }

            
        }
    }
}