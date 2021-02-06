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
    [Authorize(Roles = "Administrador,Coordenador,Regente")]
    public class ParticipanteEventoesController : Controller
    {
        private CoreAdmChamepeDbEntities db = new CoreAdmChamepeDbEntities();
        private ApplicationDbContext dbUser = new ApplicationDbContext();

        // GET: ParticipanteEventoes
        public ActionResult Index()
        {        
            IEnumerable<ParticipanteEvento> participanteEventoes = new List<ParticipanteEvento>();
            if (User.IsInRole("Administrador"))
            {
                 participanteEventoes = db.ParticipanteEventoes.Include(p => p.Evento).Include(p => p.Igreja);
            }
            else
            {
                 participanteEventoes = db.ParticipanteEventoes.Include(p => p.Evento).Include(p => p.Igreja).ToList().Where(p => p.UserId == dbUser.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault().Id);
            }

            ViewBag.TotalGeralPessoasCadastradas = db.ParticipanteEventoes.Count();
            return View(participanteEventoes.ToList());
        }

        // GET: ParticipanteEventoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteEvento participanteEvento = db.ParticipanteEventoes.Find(id);
            if (participanteEvento == null)
            {
                return HttpNotFound();
            }
            return View(participanteEvento);
        }

        // GET: ParticipanteEventoes/Create
        public ActionResult Create(int eventoId)
        {
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "EventoDescricao", eventoId);
            ViewBag.IgrejaId = new SelectList(db.Igrejas, "IgrejaId", "IgrejaDescricao");
            ViewBag.Evento = eventoId;
            return View();
        }

        // POST: ParticipanteEventoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartcipanteNomeCompleto,ParticipanteRg,ParticipanteEmail,ParticipanteTelefone,ParticipanteIdade,IgrejaId,EventoId")] ParticipanteEvento participanteEvento)
        {
            ViewBag.Evento = participanteEvento.EventoId;
            if (ModelState.IsValid)
            {                
                if (db.Eventoes.Where(x => x.EventoId == participanteEvento.EventoId).FirstOrDefault().EventoLimitePessoas <= db.ParticipanteEventoes.Count())
                {
                    ViewBag.error = "A quantidade de pessoas limite para o evento foi alcançada! Não é possivel cadastrar mais!";                     
                }                
                else
                {
                    if(db.ParticipanteEventoes.Where(x => x.ParticipanteRg == participanteEvento.ParticipanteRg).Count() > 0)
                    {
                        ViewBag.error = "Já existe participante cadastrado com este CPF!";
                    }
                    else
                    {
                        participanteEvento.UserId = dbUser.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault().Id;
                        db.ParticipanteEventoes.Add(participanteEvento);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }                   
                }               
            }

            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "EventoDescricao", participanteEvento.EventoId);
            ViewBag.IgrejaId = new SelectList(db.Igrejas, "IgrejaId", "IgrejaDescricao", participanteEvento.IgrejaId);
            return View(participanteEvento);
        }

        // GET: ParticipanteEventoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteEvento participanteEvento = db.ParticipanteEventoes.Find(id);
            if (participanteEvento == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "EventoDescricao", participanteEvento.EventoId);
            ViewBag.IgrejaId = new SelectList(db.Igrejas, "IgrejaId", "IgrejaDescricao", participanteEvento.IgrejaId);
            return View(participanteEvento);
        }

        // POST: ParticipanteEventoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticipanteEventoId,PartcipanteNomeCompleto,ParticipanteRg,ParticipanteEmail,ParticipanteTelefone,ParticipanteIdade,IgrejaId,EventoId")] ParticipanteEvento participanteEvento)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                participanteEvento.UserId = dbUser.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault().Id;
                db.Entry(participanteEvento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "EventoDescricao", participanteEvento.EventoId);
            ViewBag.IgrejaId = new SelectList(db.Igrejas, "IgrejaId", "IgrejaDescricao", participanteEvento.IgrejaId);
            return View(participanteEvento);
        }

        // GET: ParticipanteEventoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipanteEvento participanteEvento = db.ParticipanteEventoes.Find(id);
            if (participanteEvento == null)
            {
                return HttpNotFound();
            }
            return View(participanteEvento);
        }

        // POST: ParticipanteEventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated) {
                ParticipanteEvento participanteEvento = db.ParticipanteEventoes.Find(id);
                db.ParticipanteEventoes.Remove(participanteEvento);
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
