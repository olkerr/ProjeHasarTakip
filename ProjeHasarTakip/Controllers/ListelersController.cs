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
    public class ListelersController : Controller
    {
        private ProjeHasarDbContext db = new ProjeHasarDbContext();

        // GET: Listelers
        public async Task<ActionResult> Index()
        {
            return View(await db.Listelers.ToListAsync());
        }

        // GET: Listelers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listeler listeler = await db.Listelers.FindAsync(id);
            if (listeler == null)
            {
                return HttpNotFound();
            }
            return View(listeler);
        }

        // GET: Listelers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ListeId,ListeAd,Tarih")] Listeler listeler)
        {
            if (ModelState.IsValid)
            {
                db.Listelers.Add(listeler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(listeler);
        }

        // GET: Listelers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listeler listeler = await db.Listelers.FindAsync(id);
            if (listeler == null)
            {
                return HttpNotFound();
            }
            return View(listeler);
        }

        // POST: Listelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ListeId,ListeAd,Tarih")] Listeler listeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listeler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(listeler);
        }

        // GET: Listelers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listeler listeler = await db.Listelers.FindAsync(id);
            if (listeler == null)
            {
                return HttpNotFound();
            }
            return View(listeler);
        }

        // POST: Listelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Listeler listeler = await db.Listelers.FindAsync(id);
            db.Listelers.Remove(listeler);
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
