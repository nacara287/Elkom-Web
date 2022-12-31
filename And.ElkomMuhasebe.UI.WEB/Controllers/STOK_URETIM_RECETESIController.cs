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
    public class STOK_URETIM_RECETESIController : Controller
    {
        private FirmaBaseDB db = new FirmaBaseDB();

        // GET: STOK_URETIM_RECETESI
        public ActionResult Index()
        {
            return View(db.STOK_URETIM_RECETESI.ToList());
        }

        // GET: STOK_URETIM_RECETESI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOK_URETIM_RECETESI sTOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Find(id);
            if (sTOK_URETIM_RECETESI == null)
            {
                return HttpNotFound();
            }
            return View(sTOK_URETIM_RECETESI);
        }

        // GET: STOK_URETIM_RECETESI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STOK_URETIM_RECETESI/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RECETEKODU,deleted,RECETEADI,TARIH,OZELKOD,ACIKLAMA,MALIYETTURU,SON_URETIM_TARIHI,URETIM_ADET,URETIM_TIPI,URETIM_GURUBU,SON_URETIM_MALIYET,KDV_EKLE,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] STOK_URETIM_RECETESI sTOK_URETIM_RECETESI)
        {
            if (ModelState.IsValid)
            {
                db.STOK_URETIM_RECETESI.Add(sTOK_URETIM_RECETESI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTOK_URETIM_RECETESI);
        }

        // GET: STOK_URETIM_RECETESI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOK_URETIM_RECETESI sTOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Find(id);
            if (sTOK_URETIM_RECETESI == null)
            {
                return HttpNotFound();
            }
            return View(sTOK_URETIM_RECETESI);
        }

        // POST: STOK_URETIM_RECETESI/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RECETEKODU,deleted,RECETEADI,TARIH,OZELKOD,ACIKLAMA,MALIYETTURU,SON_URETIM_TARIHI,URETIM_ADET,URETIM_TIPI,URETIM_GURUBU,SON_URETIM_MALIYET,KDV_EKLE,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] STOK_URETIM_RECETESI sTOK_URETIM_RECETESI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTOK_URETIM_RECETESI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTOK_URETIM_RECETESI);
        }

        // GET: STOK_URETIM_RECETESI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOK_URETIM_RECETESI sTOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Find(id);
            if (sTOK_URETIM_RECETESI == null)
            {
                return HttpNotFound();
            }
            return View(sTOK_URETIM_RECETESI);
        }

        // POST: STOK_URETIM_RECETESI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STOK_URETIM_RECETESI sTOK_URETIM_RECETESI = db.STOK_URETIM_RECETESI.Find(id);
            db.STOK_URETIM_RECETESI.Remove(sTOK_URETIM_RECETESI);
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
