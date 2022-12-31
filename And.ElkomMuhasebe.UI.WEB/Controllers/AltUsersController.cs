using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using And.ElkomMuhasebe.Core.Model;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class AltUsersController : Controller
    {
        private AndDB db = new AndDB();

        // GET: AltUsers
        public ActionResult Index()
        {
            var user = Session["LoginUser"] as User; 
        
            return View(db.altUsers.Where(x=>x.UserID== user.ID).ToList());
        }

        // GET: AltUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltUser altUser = db.altUsers.Find(id);
            if (altUser == null)
            {
                return HttpNotFound();
            }
            return View(altUser);
        }

        // GET: AltUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AltUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
    
        public JsonResult Create(AltUser altUser,List<string>Ekleme, List<string>Gorme, List<string>Silme, List<string> Degistirme)
        {
           
                altUser.CreateDate = DateTime.Now;
                var user= Session["LoginUser"] as User; ;
                altUser.CreateUserID = user.ID;
            foreach(var item in Degistirme)
                altUser.degistir += item + ",";
            foreach (var item in Ekleme)
                altUser.ekleme += item + ",";
            foreach (var item in Gorme)
                altUser.görme += item + ",";
            foreach (var item in Silme)
                altUser.silme += item + ",";
         
            
                altUser.UserID = user.ID;
            if (db.altUsers.Where(x => x.username == user.username && x.mail == user.mail).Count() > 0)
            {
                db.Dispose();
                return Json("Başarısız!");
            }
            else { 
                db.altUsers.Add(altUser);
                db.SaveChanges();
                db.Dispose();
                return Json("Başarılı");
            }

        }

        // GET: AltUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltUser altUser = db.altUsers.Find(id);
            if (altUser == null)
            {
                return HttpNotFound();
            }
            return View(altUser);
        }

        // POST: AltUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      
        [HttpPost]

        public JsonResult Edit(AltUser altUser, List<string> Ekleme, List<string> Gorme, List<string> Silme, List<string> Degistirme)
        {
           

         

            altUser.degistir = "";
            altUser.ekleme = "";
            altUser.görme = "";
            altUser.silme = "";
            foreach (var item in Degistirme)
                altUser.degistir += item + ",";
            foreach (var item in Ekleme)
                altUser.ekleme += item + ",";
            foreach (var item in Gorme)
                altUser.görme += item + ",";
            foreach (var item in Silme)
                altUser.silme += item + ",";


            var user = db.altUsers.Find(altUser.ID);
            user.görme = altUser.görme;
            user.silme = altUser.silme;
            user.ekleme = altUser.ekleme;
            user.degistir = altUser.degistir;
            user.password = altUser.password;
            user.name = altUser.name;
            user.Actıve = altUser.Actıve;
            user.UpdateDate = DateTime.Now;
            user.UpdateUserID = 1;
            user.mail = altUser.mail;
            user.surname = altUser.surname;
            user.telephone = altUser.telephone;

      
      
                db.SaveChanges();
                db.Dispose();
                return Json("Başarılı");
           

        }

        // GET: AltUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltUser altUser = db.altUsers.Find(id);
            if (altUser == null)
            {
                return HttpNotFound();
            }
            return View(altUser);
        }

        // POST: AltUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AltUser altUser = db.altUsers.Find(id);
            db.altUsers.Remove(altUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
