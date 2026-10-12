using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoomsdayArmadurasMvc.Models;

namespace DoomsdayArmadurasMvc.Controllers
{
    public class ArmadurasController : Controller
    {
        private DoomsdayDbContext db = new DoomsdayDbContext();

        // GET: Armaduras
        public ActionResult Index()
        {
            var armaduras = db.Armaduras.Include(a => a.Reino);
            return View(armaduras.ToList());
        }

        // GET: Armaduras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadura armadura = db.Armaduras.Find(id);
            if (armadura == null)
            {
                return HttpNotFound();
            }
            return View(armadura);
        }

        // GET: Armaduras/Create
        public ActionResult Create()
        {
            ViewBag.ReinoId = new SelectList(db.Reinos, "ReinoId", "Nombre");
            return View();
        }

        // POST: Armaduras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArmaduraId,Nombre,Nivel,Portador,ReinoId")] Armadura armadura)
        {
            if (ModelState.IsValid)
            {
                db.Armaduras.Add(armadura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReinoId = new SelectList(db.Reinos, "ReinoId", "Nombre", armadura.ReinoId);
            return View(armadura);
        }

        // GET: Armaduras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadura armadura = db.Armaduras.Find(id);
            if (armadura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReinoId = new SelectList(db.Reinos, "ReinoId", "Nombre", armadura.ReinoId);
            return View(armadura);
        }

        // POST: Armaduras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArmaduraId,Nombre,Nivel,Portador,ReinoId")] Armadura armadura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armadura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReinoId = new SelectList(db.Reinos, "ReinoId", "Nombre", armadura.ReinoId);
            return View(armadura);
        }

        // GET: Armaduras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadura armadura = db.Armaduras.Find(id);
            if (armadura == null)
            {
                return HttpNotFound();
            }
            return View(armadura);
        }

        // POST: Armaduras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armadura armadura = db.Armaduras.Find(id);
            db.Armaduras.Remove(armadura);
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
