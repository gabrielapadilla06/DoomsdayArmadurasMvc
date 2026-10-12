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
    public class ReinosController : Controller
    {
        private DoomsdayDbContext db = new DoomsdayDbContext();

        // GET: Reinos
        public ActionResult Index()
        {
            return View(db.Reinos.ToList());
        }

        // GET: Reinos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reino reino = db.Reinos.Find(id);
            if (reino == null)
            {
                return HttpNotFound();
            }
            return View(reino);
        }

        // GET: Reinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reinos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReinoId,Nombre,Descripcion")] Reino reino)
        {
            if (ModelState.IsValid)
            {
                db.Reinos.Add(reino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reino);
        }

        // GET: Reinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reino reino = db.Reinos.Find(id);
            if (reino == null)
            {
                return HttpNotFound();
            }
            return View(reino);
        }

        // POST: Reinos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReinoId,Nombre,Descripcion")] Reino reino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reino);
        }

        // GET: Reinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reino reino = db.Reinos.Find(id);
            if (reino == null)
            {
                return HttpNotFound();
            }
            return View(reino);
        }

        // POST: Reinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reino reino = db.Reinos.Find(id);
            db.Reinos.Remove(reino);
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
