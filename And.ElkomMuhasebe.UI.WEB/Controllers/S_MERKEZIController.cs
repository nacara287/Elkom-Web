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
using And.ElkomMuhasebe.Core.Model.Entity.FirmaDB;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class S_MERKEZIController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();

        // GET: KUR_BASLIK
        public int userid = 0;
        public bool ekleme = false;
        public bool degistirme = false;
        public bool silme = false;
        public bool gorme = false;
        public void changestring()
        {
            if ((Session["LoginUser"] == null || Session["SeciliFirma"] == null) && (Session["LoginAltUser"] == null || Session["SeciliFirma"] == null)) { Response.Redirect("/Home"); }
            else
            {
                if (Session["LoginAltUser"] != null)
                {
                    var alt = Session["LoginAltUser"] as And.ElkomMuhasebe.Core.Model.Entity.Admin.AltUser;
                    userid = alt.ID;
                    if (alt.görme.Contains("Bankalar"))
                    {
                        gorme = true;
                        var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                        if (db.Database.Connection.State != ConnectionState.Open)
                        {
                            db.Database.Connection.Open();
                            db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                            db.SaveChanges();
                        }
                        if (alt.ekleme.Contains("Bankalar"))
                            ekleme = true;
                        if (alt.silme.Contains("Bankalar"))
                            silme = true;
                        if (alt.degistir.Contains("Bankalar"))
                            degistirme = true;

                    }

                }
                else
                {
                    var firma = Session["SeciliFirma"] as Core.Model.Entity.Admin.UserFirma;
                    if (db.Database.Connection.State != ConnectionState.Open)
                    {
                        db.Database.Connection.Open();
                        db.Database.Connection.ChangeDatabase(firma.DatabaseName);

                        db.SaveChanges();
                    }
                }
            }
        }
        [HttpPost]
        public JsonResult getsmerkezi(string term, string _type, string q)
        {



            changestring();


            var data = db.SORUMLULUK_MERKEZI.ToList();





            return Json(data, JsonRequestBehavior.AllowGet);







        }
        public ActionResult Index()
        {
            changestring();
           
            return View(db.SORUMLULUK_MERKEZI.ToList());
        }

        // GET: KUR_BASLIK/Details/5
        public ActionResult Details(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KUR_BASLIK kUR_BASLIK = db.KUR_BASLIK.Find(id);
            if (kUR_BASLIK == null)
            {
                return HttpNotFound();
            }
            return View(kUR_BASLIK);
        }

        // GET: KUR_BASLIK/Create
        public ActionResult Create()
        {
            changestring();
            SORUMLULUK_MERKEZI  smer= new SORUMLULUK_MERKEZI();
            smer.CreateDate = DateTime.Now;
            smer.CreateUserID = userid;
            return View(smer);
        }

        // POST: KUR_BASLIK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SORUMLULUK_MERKEZI sORUMLULUK_MERKEZI)
        {
            changestring();
            if (ModelState.IsValid)
            {
                db.SORUMLULUK_MERKEZI.Add(sORUMLULUK_MERKEZI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sORUMLULUK_MERKEZI);
        }

        // GET: KUR_BASLIK/Edit/5
        public ActionResult Edit(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SORUMLULUK_MERKEZI kUR_BASLIK = db.SORUMLULUK_MERKEZI.Find(id);
            if (kUR_BASLIK == null)
            {
                return HttpNotFound();
            }
            return View(kUR_BASLIK);
        }

        // POST: KUR_BASLIK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SORUMLULUK_MERKEZI sORUMLULUK_MERKEZI)
        {
            changestring();
            if (ModelState.IsValid)
            {
                db.Entry(sORUMLULUK_MERKEZI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sORUMLULUK_MERKEZI);
        }

        // GET: KUR_BASLIK/Delete/5
        public ActionResult Delete(int? id)
        {
            changestring();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SORUMLULUK_MERKEZI kUR_BASLIK = db.SORUMLULUK_MERKEZI.Find(id);
            if (kUR_BASLIK == null)
            {
                return HttpNotFound();
            }
            return View(kUR_BASLIK);
        }

        // POST: KUR_BASLIK/Delete/5
        [HttpPost, ActionName("Delete")]
  
        public JsonResult DeleteConfirmed(int id)
        {
            SORUMLULUK_MERKEZI kUR_BASLIK = db.SORUMLULUK_MERKEZI.Find(id);
            db.SORUMLULUK_MERKEZI.Remove(kUR_BASLIK);
            db.SaveChanges();
            return Json("BAŞARILI");
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
