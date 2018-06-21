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
    public class AsesoresController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Asesores
        public ActionResult Index()
        {
            return View(db.Asesores.ToList());
        }

        // GET: Asesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesor asesor = db.Asesores.Find(id);
            if (asesor == null)
            {
                return HttpNotFound();
            }
            return View(asesor);
        }

        // GET: Asesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asesores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono")] Asesor asesor)
        {
            if (ModelState.IsValid)
            {
                db.Asesores.Add(asesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asesor);
        }

        // GET: Asesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesor asesor = db.Asesores.Find(id);
            if (asesor == null)
            {
                return HttpNotFound();
            }
            return View(asesor);
        }

        // POST: Asesores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono")] Asesor asesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asesor);
        }

        // GET: Asesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesor asesor = db.Asesores.Find(id);
            if (asesor == null)
            {
                return HttpNotFound();
            }
            return View(asesor);
        }

        // POST: Asesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asesor asesor = db.Asesores.Find(id);
            db.Asesores.Remove(asesor);
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
