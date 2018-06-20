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
    public class prototiposController : Controller
    {
        private DulsaWebEntities db = new DulsaWebEntities();

        // GET: prototipos
        public ActionResult Index()
        {
            return View(db.prototipos.ToList());
        }

        // GET: prototipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prototipos prototipos = db.prototipos.Find(id);
            if (prototipos == null)
            {
                return HttpNotFound();
            }
            return View(prototipos);
        }

        // GET: prototipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: prototipos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prototipo,Prototipo,M2")] prototipos prototipos)
        {
            if (ModelState.IsValid)
            {
                db.prototipos.Add(prototipos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prototipos);
        }

        // GET: prototipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prototipos prototipos = db.prototipos.Find(id);
            if (prototipos == null)
            {
                return HttpNotFound();
            }
            return View(prototipos);
        }

        // POST: prototipos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prototipo,Prototipo,M2")] prototipos prototipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prototipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prototipos);
        }

        // GET: prototipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prototipos prototipos = db.prototipos.Find(id);
            if (prototipos == null)
            {
                return HttpNotFound();
            }
            return View(prototipos);
        }

        // POST: prototipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prototipos prototipos = db.prototipos.Find(id);
            db.prototipos.Remove(prototipos);
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
