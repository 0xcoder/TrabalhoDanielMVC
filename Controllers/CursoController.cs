using AlunoCurso.Context;
using AlunoCurso.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlunoCurso.Controllers
{
    public class CursoController : Controller
    {
        private readonly Contexto db = new Contexto();

        // GET: Curso
        public ActionResult Index()
        {
            return View(db.cursos.ToList());
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CursoModel cursoModel)
        {
            if (ModelState.IsValid) 
            {
                db.cursos.Add(cursoModel);
                db.SaveChanges();
                return RedirectToAction(nameof(Index)); 
            }
            return View(cursoModel);
        }

        public ActionResult details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            CursoModel curso = db.cursos.Find(id);
            if(curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }



        #region Edit-Get
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoModel cursoModel = db.cursos.Find(id);
            if (cursoModel == null)
            {
                return HttpNotFound();
            }
            return View(cursoModel);
        }
        #endregion

        #region Edit-Post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoModel);
        }
        #endregion

        #region Delete - GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CursoModel cursoModel = db.cursos.Find(id);

            if (cursoModel == null)
            {
                return HttpNotFound();
            }

            db.cursos.Remove(cursoModel);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        #endregion

  

    }
}