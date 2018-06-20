using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dulsa.Models;

namespace Dulsa.Controllers
{
    public class AsesoresController : Controller
    {
        private DulsaWebEntities db = new DulsaWebEntities();

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
            Asesores asesores = db.Asesores.Find(id);
            if (asesores == null)
            {
                return HttpNotFound();
            }
            return View(asesores);
        }

        // GET: Asesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asesores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asesore,Nombre,Apellido_Paterno,Apellido_Materno,Telefono")] Asesores asesores)
        {
            if (ModelState.IsValid)
            {
                db.Asesores.Add(asesores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asesores);
        }

        // GET: Asesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesores asesores = db.Asesores.Find(id);
            if (asesores == null)
            {
                return HttpNotFound();
            }
            return View(asesores);
        }

        // POST: Asesores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asesore,Nombre,Apellido_Paterno,Apellido_Materno,Telefono")] Asesores asesores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asesores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asesores);
        }

        // GET: Asesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asesores asesores = db.Asesores.Find(id);
            if (asesores == null)
            {
                return HttpNotFound();
            }
            return View(asesores);
        }

        // POST: Asesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asesores asesores = db.Asesores.Find(id);
            db.Asesores.Remove(asesores);
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
