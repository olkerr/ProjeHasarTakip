using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjeHasarTakip.Models.Arac;
using ProjeHasarTakip.Models.DataContext;

namespace ProjeHasarTakip.Controllers
{
    public class AraclarsController : Controller
    {
        private ProjeHasarDbContext db = new ProjeHasarDbContext();

        // GET: Araclars
        public async Task<ActionResult> Index()
        {
            return View(await db.Araclars.ToListAsync());
        }

        // GET: Araclars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araclar araclar = await db.Araclars.FindAsync(id);
            if (araclar == null)
            {
                return HttpNotFound();
            }
            return View(araclar);
        }

        // GET: Araclars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Araclars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AracId,Arackod,AracPlaka,AracModel,AracMarka,AracTip,AracDurum,AracKonum,AracMuayene,AracResim")] Araclar araclar)
        {
            if (ModelState.IsValid)
            {
                db.Araclars.Add(araclar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(araclar);
        }

        // GET: Araclars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araclar araclar = await db.Araclars.FindAsync(id);
            if (araclar == null)
            {
                return HttpNotFound();
            }
            return View(araclar);
        }

        // POST: Araclars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AracId,Arackod,AracPlaka,AracModel,AracMarka,AracTip,AracDurum,AracKonum,AracMuayene,AracResim")] Araclar araclar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(araclar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(araclar);
        }

        // GET: Araclars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araclar araclar = await db.Araclars.FindAsync(id);
            if (araclar == null)
            {
                return HttpNotFound();
            }
            return View(araclar);
        }

        // POST: Araclars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Araclar araclar = await db.Araclars.FindAsync(id);
            db.Araclars.Remove(araclar);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> AracveHasarlari()
        {
            var araclarList = await db.Araclars.Include(a => a.HasarKayitlars).ToListAsync();
            return View(araclarList);
        }




    }
}


