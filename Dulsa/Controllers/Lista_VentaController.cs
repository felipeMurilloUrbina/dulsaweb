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
    public class Lista_VentaController : Controller
    {
        private DulsaWebEntities db = new DulsaWebEntities();

        // GET: Lista_Venta
        public ActionResult Index()
        {
            var lista_Venta = db.Lista_Venta.Include(l => l.prototipos);
            return View(lista_Venta.ToList());
        }

        // GET: Lista_Venta/Details/5
        public ActionResult Details(int? id_lista, int? id_prototipo)
        {
            if (id_lista == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_Venta lista_Venta = db.Lista_Venta.Find(id_lista, id_prototipo);
            if (lista_Venta == null)
            {
                return HttpNotFound();
            }
            return View(lista_Venta);
        }

        // GET: Lista_Venta/Create
        public ActionResult Create()
        {
            ViewBag.id_prototipo = new SelectList(db.prototipos, "id_prototipo", "Prototipo");
            return View();
        }

        // POST: Lista_Venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_lista,id_prototipo,Precio_Venta,Estatus")] Lista_Venta lista_Venta)
        {
            if (ModelState.IsValid)
            {
                db.Lista_Venta.Add(lista_Venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_prototipo = new SelectList(db.prototipos, "id_prototipo", "Prototipo", lista_Venta.id_prototipo);
            return View(lista_Venta);
        }

        // GET: Lista_Venta/Edit/5
        public ActionResult Edit(int? id_lista,  int? id_prototipo)
        {
            if (id_lista == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_Venta lista_Venta = db.Lista_Venta.Find(id_lista, id_prototipo);
            if (lista_Venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_prototipo = new SelectList(db.prototipos, "id_prototipo", "Prototipo", lista_Venta.id_prototipo);
            return View(lista_Venta);
        }

        // POST: Lista_Venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_lista,id_prototipo,Precio_Venta,Estatus")] Lista_Venta lista_Venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista_Venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_prototipo = new SelectList(db.prototipos, "id_prototipo", "Prototipo", lista_Venta.id_prototipo);
            return View(lista_Venta);
        }

        // GET: Lista_Venta/Delete/5
        public ActionResult Delete(int? id_lista, int? id_prototipo)
        {
            if (id_lista == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_Venta lista_Venta = db.Lista_Venta.Find(id_lista, id_prototipo);
            if (lista_Venta == null)
            {
                return HttpNotFound();
            }
            return View(lista_Venta);
        }

        // POST: Lista_Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id_lista, int id_prototipo)
        {
            Lista_Venta lista_Venta = db.Lista_Venta.Find(id_lista, id_prototipo);
            db.Lista_Venta.Remove(lista_Venta);
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
