using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoreAdmChamepe.Models;
using CoreAdmChamepe.Models.Context;

namespace CoreAdmChamepe.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class IgrejasController : Controller
    {
        private CoreAdmChamepeDbEntities db = new CoreAdmChamepeDbEntities();
        private ApplicationDbContext dbUser = new ApplicationDbContext();

        // GET: Igrejas
        public ActionResult Index()
        {
            return View(db.Igrejas.ToList());
        }

        // GET: Igrejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igreja igreja = db.Igrejas.Find(id);
            if (igreja == null)
            {
                return HttpNotFound();
            }
            return View(igreja);
        }

        // GET: Igrejas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Igrejas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IgrejaId,IgrejaDescricao,IgrejaStatus,IgrejaPastorDescricao,IgrejaContrato,IgrejaSetor,IgrejaDataCadastro,UserId")] Igreja igreja)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                igreja.UserId = dbUser.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault().Id;
                db.Igrejas.Add(igreja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(igreja);
        }

        // GET: Igrejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igreja igreja = db.Igrejas.Find(id);
            if (igreja == null)
            {
                return HttpNotFound();
            }
            return View(igreja);
        }

        // POST: Igrejas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IgrejaId,IgrejaDescricao,IgrejaStatus,IgrejaPastorDescricao,IgrejaContrato,IgrejaSetor,IgrejaDataCadastro,UserId")] Igreja igreja)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                igreja.UserId = dbUser.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault().Id;
                db.Entry(igreja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(igreja);
        }

        // GET: Igrejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Igreja igreja = db.Igrejas.Find(id);
            if (igreja == null)
            {
                return HttpNotFound();
            }
            return View(igreja);
        }

        // POST: Igrejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Igreja igreja = db.Igrejas.Find(id);
                db.Igrejas.Remove(igreja);
                db.SaveChanges();
            }           
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
