using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dulsa.Modelo;

namespace Dulsa.Controllers
{
    public class PrototiposController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Prototipoes
        public ActionResult Index()
        {
            return View(db.Prototipos.ToList());
        }

        // GET: Prototipoes/Details/5
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

        // GET: Prototipoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prototipoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Prototipoes/Edit/5
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

        // POST: Prototipoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Prototipoes/Delete/5
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

        // POST: Prototipoes/Delete/5
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
