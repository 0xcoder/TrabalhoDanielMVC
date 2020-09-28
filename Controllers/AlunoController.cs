using AlunoCurso.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AlunoCurso.Models;
using System.Net;

namespace AlunoCurso.Controllers
{
    public class AlunoController : Controller
    {
        private readonly Contexto db = new Contexto();


        public ActionResult Index()
        {
            var alunos = db.alunos.Include(c => c.Curso).ToList();
            return View(alunos);
        }

        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.cursos, "Id", "Curso");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                db.alunos.Add(alunoModel);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CursoId = new SelectList(db.cursos, "Id", "Curso");
            return View(alunoModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlunoModel alunoModel = db.alunos.Include(c => c.Curso).First(a => a.Id == id);

            if (alunoModel == null)
            {
                HttpNotFound();
            }

            return View(alunoModel);
        }


        #region Edit-Get
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlunoModel aluno = db.alunos.Where(a => a.Id == id).FirstOrDefault();
            ViewBag.CursoId = new SelectList(db.cursos, "Id", "Curso");
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }
        #endregion

        #region Edit-Post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(AlunoModel aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CursoId = new SelectList(db.cursos, "Id", "Curso");
            return View(aluno);
        }
        #endregion

        #region Delete - GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlunoModel alunoModel = db.alunos.Find(id);

            if (alunoModel == null)
            {
                return HttpNotFound();
            }

            db.alunos.Remove(alunoModel);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        #endregion









    }
}