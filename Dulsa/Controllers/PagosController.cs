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
    public class PagosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pagos
        public ActionResult Index()
        {
            var pagos = db.Pagos.Include(p => p.Cliente).Include(p => p.Etapa).Include(p => p.Lote).Include(p => p.Prototipo);
            return View(pagos.ToList());
        }

        // GET: Pagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        [HttpGet]
        public JsonResult GetCliente(int clienteId)
        {
            var cliente = db.Clientes.Find(clienteId);
            if (cliente == null)
                return Json("No Existe");
            else
                return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            //var clientes = db.Clientes.ToList();
            //var etapas = db.Etapas.ToList();
            //var lotes = db.Lotes.ToList();
            //var prototipos = db.Prototipos.ToList();
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre");
            ViewBag.EtapaId = new SelectList(db.Etapas, "Id", "Descripcion");
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Estatus");
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion");
            return View();
        }

        // POST: Pagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,PrototipoId,EtapaId,LoteId,Concepto,Estatus,Importe,Fecha")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Pagos.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", pago.ClienteId);
            ViewBag.EtapaId = new SelectList(db.Etapas, "Id", "Descripcion", pago.EtapaId);
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Estatus", pago.LoteId);
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", pago.PrototipoId);
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", pago.ClienteId);
            ViewBag.EtapaId = new SelectList(db.Etapas, "Id", "Descripcion", pago.EtapaId);
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Estatus", pago.LoteId);
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", pago.PrototipoId);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,PrototipoId,EtapaId,LoteId,Concepto,Estatus,Importe,Fecha")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", pago.ClienteId);
            ViewBag.EtapaId = new SelectList(db.Etapas, "Id", "Descripcion", pago.EtapaId);
            ViewBag.LoteId = new SelectList(db.Lotes, "Id", "Estatus", pago.LoteId);
            ViewBag.PrototipoId = new SelectList(db.Prototipos, "Id", "Descripcion", pago.PrototipoId);
            return View(pago);
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pago pago = db.Pagos.Find(id);
            db.Pagos.Remove(pago);
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
