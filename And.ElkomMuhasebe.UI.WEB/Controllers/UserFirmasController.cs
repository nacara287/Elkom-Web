using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using And.ElkomMuhasebe.Core.Model;
using And.ElkomMuhasebe.Core.Model.Entity;
using And.ElkomMuhasebe.Core.Model.Entity.Admin;
using Npgsql;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class UserFirmasController : Controller
    {
        private AndDB db = new AndDB();

        // GET: UserFirmas
        public ActionResult Index()
        {
            var userFirmas = db.userFirmas.Include(u => u.User);
            return View(userFirmas.ToList());
        }

        // GET: UserFirmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Core.Model.Entity.Admin.UserFirma userFirma = db.userFirmas.Find(id);
            if (userFirma == null)
            {
                return HttpNotFound();
            }
            return View(userFirma);
        }

        // GET: UserFirmas/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "ID", "username");
            return View();
        }

        // POST: UserFirmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Companyname,Using,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Core.Model.Entity.Admin.UserFirma userFirma)
        {
            if (ModelState.IsValid)
            {
                var firmalar = db.userFirmas.Where(x => x.Companyname == userFirma.Companyname).ToList();
                if (firmalar.Count== 0) { 
                userFirma.CreateDate = DateTime.Now;
                userFirma.CreateUserID = 1;
                    User loginuser = Session["LoginUser"] as User;

                    userFirma.UserID = loginuser.ID;

                db.userFirmas.Add(userFirma);
                db.SaveChanges();

              NpgsqlConnection connection = new NpgsqlConnection(@"Host=93.104.209.108;Username=postgres;Password=287287mb");
                string databasename = userFirma.Companyname;
                NpgsqlCommand command = new NpgsqlCommand("CREATE DATABASE "+databasename+";", connection);
           

              
                  connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
               
                 var config = new And.ElkomMuhasebe.Core.Model.Migrations.ConfigurationFirma();
                    FirmaBaseDB dba = new FirmaBaseDB();
                    config.ManualSeed(dba, @"Host=93.104.209.108;Database=" + databasename + ";Username=postgres;Password=287287mb");
                    return RedirectToAction("Index");
                }
                else
                {
                   
                    ModelState.AddModelError("", "Bu isim kullanılıyor lütfen başka bir isim seçiniz");
                }
 
            }

            ViewBag.UserID = new SelectList(db.Users, "ID", "username", userFirma.UserID);
            return View(userFirma);
        }

        // GET: UserFirmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Core.Model.Entity.Admin.UserFirma userFirma = db.userFirmas.Find(id);
            if (userFirma == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "username", userFirma.UserID);
            return View(userFirma);
        }

        // POST: UserFirmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Companyname,Using,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Core.Model.Entity.Admin.UserFirma userFirma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userFirma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "username", userFirma.UserID);
            return View(userFirma);
        }

        // GET: UserFirmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Core.Model.Entity.Admin.UserFirma userFirma = db.userFirmas.Find(id);
            if (userFirma == null)
            {
                return HttpNotFound();
            }
            return View(userFirma);
        }

        // POST: UserFirmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Core.Model.Entity.Admin.UserFirma userFirma = db.userFirmas.Find(id);
         
            NpgsqlConnection connection = new NpgsqlConnection(@"Host=93.104.209.108;Username=postgres;Password=287287mb");
            string databasename = userFirma.Companyname;
            NpgsqlCommand command = new NpgsqlCommand("Delete DATABASE " + databasename + ";", connection);



            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            db.userFirmas.Remove(userFirma);
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
