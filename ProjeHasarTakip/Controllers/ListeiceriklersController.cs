using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjeHasarTakip.Models;
using ProjeHasarTakip.Models.DataContext;

namespace ProjeHasarTakip.Controllers
{
    public class ListeiceriklersController : Controller
    {
        private ProjeHasarDbContext db = new ProjeHasarDbContext();

        // GET: Listeiceriklers
        public async Task<ActionResult> Index()
        {
            var listeiceriklers = db.Listeiceriklers.Include(l => l.Araclar).Include(l => l.Listeler);
            return View(await listeiceriklers.ToListAsync());
        }

        // GET: Listeiceriklers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listeicerikler listeicerikler = await db.Listeiceriklers.FindAsync(id);
            if (listeicerikler == null)
            {
                return HttpNotFound();
            }
            return View(listeicerikler);
        }

        // GET: Listeiceriklers/Create
        public ActionResult Create()
        {
            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod");
            ViewBag.ListeId = new SelectList(db.Listelers, "ListeId", "ListeAd");
            return View();
        }

        // POST: Listeiceriklers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ListeicerikId,ListeId,AracId,Aciklama")] Listeicerikler listeicerikler)
        {
            if (ModelState.IsValid)
            {
                db.Listeiceriklers.Add(listeicerikler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", listeicerikler.AracId);
            ViewBag.ListeId = new SelectList(db.Listelers, "ListeId", "ListeAd", listeicerikler.ListeId);
            return View(listeicerikler);
        }

        // GET: Listeiceriklers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listeicerikler listeicerikler = await db.Listeiceriklers.FindAsync(id);
            if (listeicerikler == null)
            {
                return HttpNotFound();
            }
            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", listeicerikler.AracId);
            ViewBag.ListeId = new SelectList(db.Listelers, "ListeId", "ListeAd", listeicerikler.ListeId);
            return View(listeicerikler);
        }

        // POST: Listeiceriklers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ListeicerikId,ListeId,AracId,Aciklama")] Listeicerikler listeicerikler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listeicerikler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AracId = new SelectList(db.Araclars, "AracId", "Arackod", listeicerikler.AracId);
            ViewBag.ListeId = new SelectList(db.Listelers, "ListeId", "ListeAd", listeicerikler.ListeId);
            return View(listeicerikler);
        }

        // GET: Listeiceriklers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listeicerikler listeicerikler = await db.Listeiceriklers.FindAsync(id);
            if (listeicerikler == null)
            {
                return HttpNotFound();
            }
            return View(listeicerikler);
        }

        // POST: Listeiceriklers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Listeicerikler listeicerikler = await db.Listeiceriklers.FindAsync(id);
            db.Listeiceriklers.Remove(listeicerikler);
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
