using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjeHasarTakip.Models.DataContext;
using ProjeHasarTakip.Models.Personel;

namespace ProjeHasarTakip.Controllers
{
    public class PersonellersController : Controller
    {
        private ProjeHasarDbContext db = new ProjeHasarDbContext();

        // GET: Personellers
        public ActionResult Index()
        {
            return View(db.Personellers.ToList());
        }
        public ActionResult PersonelKart()
        {
            return View(db.Personellers.ToList());
        }

        // GET: Personellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeller personeller = db.Personellers.Find(id);
            if (personeller == null)
            {
                return HttpNotFound();
            }
            return View(personeller);
        }

        // GET: Personellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Personeller personeller, HttpPostedFileBase PersonelResim)
        {
            try
            {
                if (PersonelResim != null)
                {
                    string uzanti = Path.GetExtension(PersonelResim.FileName);
                    string dosyaAdi = Path.GetFileNameWithoutExtension(PersonelResim.FileName) + "1.bölge" ;
                    string tamad = dosyaAdi + uzanti;
                    string yol = Server.MapPath("~/Img/PersonelResim/") + tamad;
                    PersonelResim.SaveAs(yol);
                    string kaydedilecekYol = "/Img/PersonelResim/" + tamad;
                    personeller.PersonelResim = kaydedilecekYol;
                    db.Personellers.Add(personeller);
                    db.SaveChanges();
                    TempData["Ok"] = "Kayıt İşlemi Başarılı";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["No"] = "Hata Oluştu";
                return RedirectToAction("Index");
            }
        }

        // GET: Personellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeller personeller = db.Personellers.Find(id);
            if (personeller == null)
            {
                return HttpNotFound();
            }
            return View(personeller);
        }

        // POST: Personellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Personeller personeller, HttpPostedFileBase PersonelResim)
        {
            if (ModelState.IsValid)
            {
                string uzanti = Path.GetExtension(PersonelResim.FileName);
                string dosyaAdi = Path.GetFileNameWithoutExtension(PersonelResim.FileName) + "_1Bolge" ;
                string tamad = dosyaAdi + uzanti;
                string yol = Server.MapPath("~/Img/PersonelResim/") + tamad;
                PersonelResim.SaveAs(yol);
                string kaydedilecekYol = "/Img/PersonelResim/" + tamad;
                personeller.PersonelResim = kaydedilecekYol;

                db.Entry(personeller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personeller);
        }

        // GET: Personellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personeller personeller = db.Personellers.Find(id);
            if (personeller == null)
            {
                return HttpNotFound();
            }
            return View(personeller);
        }

        // POST: Personellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personeller personeller = db.Personellers.Find(id);
            string resimyolu = Request.MapPath(personeller.PersonelResim);
            db.Personellers.Remove(personeller);
            if (System.IO.File.Exists(resimyolu))
            {
                System.IO.File.Delete(resimyolu);
            }
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
