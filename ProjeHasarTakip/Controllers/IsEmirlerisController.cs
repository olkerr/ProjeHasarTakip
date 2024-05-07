using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjeHasarTakip.Models.DataContext;
using ProjeHasarTakip.Models.IsEmri;

namespace ProjeHasarTakip.Controllers
{
    public class IsEmirlerisController : Controller
    {
        private ProjeHasarDbContext db = new ProjeHasarDbContext();

        // GET: IsEmirleris
        public async Task<ActionResult> Index()
        {
            var isEmirleris = db.IsEmirleris.Include(i => i.Araclars);
            return View(await isEmirleris.ToListAsync());
        }

        // GET: IsEmirleris/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsEmirleri isEmirleri = await db.IsEmirleris.FindAsync(id);
            if (isEmirleri == null)
            {
                return HttpNotFound();
            }
            return View(isEmirleri);
        }

        // GET: IsEmirleris/Create
        public ActionResult Create()
        {
            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod");
            return View();
        }

        // POST: IsEmirleris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IsEmriId,AracId,Baslik,Aciklama,OlusturulmaTarihi,OncelikDurumu,TamamlanmaOranı,TamamlanmaDurumu,TamamlanmaTarihi")] IsEmirleri isEmirleri)
        {
            if (ModelState.IsValid)
            {
                db.IsEmirleris.Add(isEmirleri);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", isEmirleri.AracId);
            return View(isEmirleri);
        }

        // GET: IsEmirleris/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsEmirleri isEmirleri = await db.IsEmirleris.FindAsync(id);
            if (isEmirleri == null)
            {
                return HttpNotFound();
            }
            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", isEmirleri.AracId);
            return View(isEmirleri);
        }

        // POST: IsEmirleris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IsEmriId,AracId,Baslik,Aciklama,OlusturulmaTarihi,OncelikDurumu,TamamlanmaOranı,TamamlanmaDurumu,TamamlanmaTarihi")] IsEmirleri isEmirleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(isEmirleri).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", isEmirleri.AracId);
            return View(isEmirleri);
        }

        // GET: IsEmirleris/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsEmirleri isEmirleri = await db.IsEmirleris.FindAsync(id);
            if (isEmirleri == null)
            {
                return HttpNotFound();
            }
            return View(isEmirleri);
        }

        // POST: IsEmirleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IsEmirleri isEmirleri = await db.IsEmirleris.FindAsync(id);
            db.IsEmirleris.Remove(isEmirleri);
            await db.SaveChangesAsync();
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
