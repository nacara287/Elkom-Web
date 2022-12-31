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
    public class KUR_BASLIKController : Controller
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
        public JsonResult getkur(string term, string _type, string q)
        {



            changestring();


            var data = db.KUR_BASLIK.ToList();





            return Json(data, JsonRequestBehavior.AllowGet);







        }
        public ActionResult Index()
        {
            changestring();
           
            return View(db.KUR_BASLIK.ToList());
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
            return View();
        }

        // POST: KUR_BASLIK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KURADI,KURKODU,KUR,Aktif,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] KUR_BASLIK kUR_BASLIK)
        {
            changestring();
            if (ModelState.IsValid)
            {
                db.KUR_BASLIK.Add(kUR_BASLIK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kUR_BASLIK);
        }

        // GET: KUR_BASLIK/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: KUR_BASLIK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KURADI,KURKODU,KUR,Aktif,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] KUR_BASLIK kUR_BASLIK)
        {
            changestring();
            if (ModelState.IsValid)
            {
                db.Entry(kUR_BASLIK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kUR_BASLIK);
        }

        // GET: KUR_BASLIK/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: KUR_BASLIK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KUR_BASLIK kUR_BASLIK = db.KUR_BASLIK.Find(id);
            db.KUR_BASLIK.Remove(kUR_BASLIK);
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
