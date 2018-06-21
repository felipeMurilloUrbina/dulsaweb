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
    public class ListaVentasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: ListaVentas
        public ActionResult Index()
        {
            var listaVenta = db.ListaVenta.Include(l => l.Prototipo);
            return View(listaVenta.ToList());
        }

        // GET: ListaVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaVenta listaVenta = db.ListaVenta.Find(id);
            if (listaVenta == null)
            {
                return HttpNotFound();
            }
            return View(listaVenta);
        }

        // GET: ListaVentas/Create
        public ActionResult Create()
        {
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion");
            return View();
        }

        // POST: ListaVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrototipoId,PrecioVenta,Estatus")] ListaVenta listaVenta)
        {
            if (ModelState.IsValid)
            {
                db.ListaVenta.Add(listaVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", listaVenta.PrototipoId);
            return View(listaVenta);
        }

        // GET: ListaVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaVenta listaVenta = db.ListaVenta.Find(id);
            if (listaVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", listaVenta.PrototipoId);
            return View(listaVenta);
        }

        // POST: ListaVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrototipoId,PrecioVenta,Estatus")] ListaVenta listaVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", listaVenta.PrototipoId);
            return View(listaVenta);
        }

        // GET: ListaVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaVenta listaVenta = db.ListaVenta.Find(id);
            if (listaVenta == null)
            {
                return HttpNotFound();
            }
            return View(listaVenta);
        }

        // POST: ListaVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaVenta listaVenta = db.ListaVenta.Find(id);
            db.ListaVenta.Remove(listaVenta);
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
