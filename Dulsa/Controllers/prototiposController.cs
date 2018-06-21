using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DulsaWeb.Modelo;

namespace Dulsa.Controllers
{
    public class PrototiposController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Prototipos
        public ActionResult Index()
        {
            return View(db.Prototipos.ToList());
        }

        // GET: Prototipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prototipo prototipo = db.Prototipos.Find(id);
            if (prototipo == null)
            {
                return HttpNotFound();
            }
            return View(prototipo);
        }

        // GET: Prototipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prototipos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,M2")] Prototipo prototipo)
        {
            if (ModelState.IsValid)
            {
                db.Prototipos.Add(prototipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prototipo);
        }

        // GET: Prototipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prototipo prototipo = db.Prototipos.Find(id);
            if (prototipo == null)
            {
                return HttpNotFound();
            }
            return View(prototipo);
        }

        // POST: Prototipos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,M2")] Prototipo prototipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prototipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prototipo);
        }

        // GET: Prototipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prototipo prototipo = db.Prototipos.Find(id);
            if (prototipo == null)
            {
                return HttpNotFound();
            }
            return View(prototipo);
        }

        // POST: Prototipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prototipo prototipo = db.Prototipos.Find(id);
            db.Prototipos.Remove(prototipo);
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
