using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BaseModels;
using SistemaMercado.Models;

namespace SistemaMercado.Controllers
{
    public class VendasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendas
        public ActionResult Index()
        {
            return View(db.Vendas.ToList());
        }

        // GET: Vendas/Detalhes/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Fazer
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendas/Fazer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendaID,FormaPag")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Vendas.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venda);
        }

        // GET: Vendas/Editar/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Editar/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendaID,FormaPag")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);
        }

        // GET: Vendas/Deletar/
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Deletar/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
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
