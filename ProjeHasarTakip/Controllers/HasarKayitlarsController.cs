using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjeHasarTakip.Models;
using ProjeHasarTakip.Models.DataContext;
using ProjeHasarTakip.Models.Personel;

namespace ProjeHasarTakip.Controllers
{
    public class HasarKayitlarsController : Controller
    {
        private ProjeHasarDbContext db = new ProjeHasarDbContext();

        // GET: HasarKayitlars1
        public ActionResult Index()
        {
            var hasarKayitlars = db.HasarKayitlars.Include(h => h.Araclars);
            return View(hasarKayitlars.ToList());
        }

        // GET: HasarKayitlars1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasarKayitlar hasarKayitlar = db.HasarKayitlars.Find(id);
            if (hasarKayitlar == null)
            {
                return HttpNotFound();
            }
            return View(hasarKayitlar);
        }

        // GET: HasarKayitlars1/Create
        public ActionResult Create()
        {
            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod");
            return View();
        }

        // POST: HasarKayitlars1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HasarKayitlar hasarKayitlar, HttpPostedFileBase HasarResim)
        {
            if (HasarResim != null)
            {
                string uzanti = Path.GetExtension(HasarResim.FileName);
                string dosyaAdi = Path.GetFileNameWithoutExtension(HasarResim.FileName) + "1.bölge";
                string tamad = dosyaAdi + uzanti;
                string yol = Server.MapPath("~/Img/HasarResim/") + tamad;
                HasarResim.SaveAs(yol);
                string kaydedilecekYol = "/Img/HasarResim/" + tamad;
                hasarKayitlar.HasarResim = kaydedilecekYol;
                db.HasarKayitlars.Add(hasarKayitlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", hasarKayitlar.AracId);
            return View(hasarKayitlar);
        }

        // GET: HasarKayitlars1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasarKayitlar hasarKayitlar = db.HasarKayitlars.Find(id);
            if (hasarKayitlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", hasarKayitlar.AracId);
            return View(hasarKayitlar);
        }

        // POST: HasarKayitlars1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HasarKayitlar hasarKayitlar)
        {
            if (ModelState.IsValid)
            {
                var eskiHasarKayit = db.HasarKayitlars.Find(hasarKayitlar.HasarKayitlarId);

                if (eskiHasarKayit != null)
                {
                    // Eğer yeni bir resim seçilmemişse, eski resmi kullan
                    if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
                    {
                        HttpPostedFileBase yeniHasarResim = Request.Files[0];

                        string uzanti = Path.GetExtension(yeniHasarResim.FileName);
                        string dosyaAdi = Path.GetFileNameWithoutExtension(yeniHasarResim.FileName) + "1.bölge";
                        string tamad = dosyaAdi + uzanti;
                        string yol = Server.MapPath("~/Img/HasarResim/") + tamad;
                        yeniHasarResim.SaveAs(yol);
                        string kaydedilecekYol = "/Img/HasarResim/" + tamad;
                        hasarKayitlar.HasarResim = kaydedilecekYol;
                    }
                    else
                    {
                        // Eğer yeni bir resim seçilmemişse, eski resmi kullan
                        hasarKayitlar.HasarResim = eskiHasarKayit.HasarResim;
                    }

                    // EntityState.Modified kullanarak değişiklikleri uygula
                    db.Entry(eskiHasarKayit).CurrentValues.SetValues(hasarKayitlar);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", hasarKayitlar.AracId);
            return View(hasarKayitlar);
        }


        // GET: HasarKayitlars1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasarKayitlar hasarKayitlar = db.HasarKayitlars.Find(id);
            if (hasarKayitlar == null)
            {
                return HttpNotFound();
            }
            return View(hasarKayitlar);
        }

        // POST: HasarKayitlars1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
{
    HasarKayitlar hasarKayitlar = db.HasarKayitlars.Find(id);

    if (hasarKayitlar != null)
    {
        // Eski resmi sil
        SilEskiResmi(hasarKayitlar.HasarResim);

        db.HasarKayitlars.Remove(hasarKayitlar);
        db.SaveChanges();
    }

    return RedirectToAction("Index");
}

private void SilEskiResmi(string eskiResimYolu)
{
    if (!string.IsNullOrEmpty(eskiResimYolu) && System.IO.File.Exists(Server.MapPath(eskiResimYolu)))
    {
        System.IO.File.Delete(Server.MapPath(eskiResimYolu));
    }
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
