using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using And.ElkomMuhasebe.Core.Model;
using And.ElkomMuhasebe.Core.Model.Entity.FirmaDB;

namespace And.ElkomMuhasebe.UI.WEB.Controllers
{
    public class BANKA_VISAController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();

        // GET: BANKA_VISA
        public ActionResult Index()
        {
            return View(db.BANKA_VISA.ToList());
        }

        // GET: BANKA_VISA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANKA_VISA bANKA_VISA = db.BANKA_VISA.Find(id);
            if (bANKA_VISA == null)
            {
                return HttpNotFound();
            }
            return View(bANKA_VISA);
        }

        // GET: BANKA_VISA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BANKA_VISA/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,INDEXNO,deleted,BANKAKODU,PORTFOYNO,DURUMU,CARI,ACIKLAMA,TARIHI,VADE,TUTAR,KOMISYON,TAHSILTARIHI,PARABIRIMI,KASA,S_MERKEZI,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] BANKA_VISA bANKA_VISA)
        {
            if (ModelState.IsValid)
            {
                db.BANKA_VISA.Add(bANKA_VISA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bANKA_VISA);
        }

        // GET: BANKA_VISA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANKA_VISA bANKA_VISA = db.BANKA_VISA.Find(id);
            if (bANKA_VISA == null)
            {
                return HttpNotFound();
            }
            return View(bANKA_VISA);
        }

        // POST: BANKA_VISA/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,INDEXNO,deleted,BANKAKODU,PORTFOYNO,DURUMU,CARI,ACIKLAMA,TARIHI,VADE,TUTAR,KOMISYON,TAHSILTARIHI,PARABIRIMI,KASA,S_MERKEZI,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] BANKA_VISA bANKA_VISA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANKA_VISA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bANKA_VISA);
        }

        // GET: BANKA_VISA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANKA_VISA bANKA_VISA = db.BANKA_VISA.Find(id);
            if (bANKA_VISA == null)
            {
                return HttpNotFound();
            }
            return View(bANKA_VISA);
        }

        // POST: BANKA_VISA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANKA_VISA bANKA_VISA = db.BANKA_VISA.Find(id);
            db.BANKA_VISA.Remove(bANKA_VISA);
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
