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
    public class EtapasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Etapas
        public ActionResult Index()
        {
            return View(db.Etapas.ToList());
        }

        // GET: Etapas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // GET: Etapas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etapas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Etapas.Add(etapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etapa);
        }

        // GET: Etapas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // POST: Etapas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etapa);
        }

        // GET: Etapas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etapa etapa = db.Etapas.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        // POST: Etapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etapa etapa = db.Etapas.Find(id);
            db.Etapas.Remove(etapa);
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
