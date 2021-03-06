﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BaseModels;
using SistemaMercado.Models;

namespace SistemaMercado.Controllers
{
    public class EnderecosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enderecos
        public ActionResult Index()
        {
            return View(db.Enderecos.ToList());
        }

        // GET: Enderecos/Detalhes/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecos/Cadastrar
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enderecos/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnderecoID,Rua,Numero,Bairro,Cidade,Estado,Cep")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Enderecos.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(endereco);
        }

        // GET: Enderecos/Editar/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecos/Editar/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnderecoID,Rua,Numero,Bairro,Cidade,Estado,Cep")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        // GET: Enderecos/Deletar/
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecos/Deletar/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Enderecos.Find(id);
            db.Enderecos.Remove(endereco);
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
