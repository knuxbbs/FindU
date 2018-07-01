using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plataforma_FindU.Models.Entity;

namespace Plataforma_FindU.Controllers
{
    public class UserController : Controller
    {
        private bd_FindU db = new bd_FindU();

        // GET: User
        public ActionResult Index()
        {
            var tb_usuario = db.tb_usuario.Include(t => t.tb_curso);
            return View(tb_usuario.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            var cod_usuario_usu = db.tb_usuario.Where(x => x.des_email_usu == User.Identity.Name).FirstOrDefault().cod_usuario_usu;
            if (cod_usuario_usu == null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(cod_usuario_usu);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_usuario);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.cod_curso_cur = new SelectList(db.tb_curso, "cod_curso_cur", "des_nome_cur");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_usuario_usu,des_nome_usu,num_idade_usu,cod_curso_cur,num_semestre_usu,des_biografia_usu,des_genero_usu,des_orientacao_usu,sts_status_usu,dat_cadastro_usu,cod_senha_usu,des_email_usu")] tb_usuario tb_usuario)
        {
            tb_usuario.sts_status_usu = true;
            tb_usuario.dat_cadastro_usu = DateTime.Now;
            tb_usuario.cod_senha_usu = Session["cod_senha_usu"].ToString();
            tb_usuario.des_email_usu = Session["des_email_usu"].ToString();
            if (ModelState.IsValid)
            {
                db.tb_usuario.Add(tb_usuario);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = tb_usuario.cod_usuario_usu });
            }

            ViewBag.cod_curso_cur = new SelectList(db.tb_curso, "cod_curso_cur", "des_nome_cur", tb_usuario.cod_curso_cur);
            return View(tb_usuario);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_curso_cur = new SelectList(db.tb_curso, "cod_curso_cur", "des_nome_cur", tb_usuario.cod_curso_cur);
            return View(tb_usuario);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_usuario_usu,des_nome_usu,num_idade_usu,cod_curso_cur,num_semestre_usu,des_biografia_usu,des_genero_usu,des_orientacao_usu,sts_status_usu,dat_cadastro_usu,cod_senha_usu,des_email_usu")] tb_usuario tb_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = tb_usuario.cod_usuario_usu });
            }
            ViewBag.cod_curso_cur = new SelectList(db.tb_curso, "cod_curso_cur", "des_nome_cur", tb_usuario.cod_curso_cur);
            return View(tb_usuario);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_usuario);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            db.tb_usuario.Remove(tb_usuario);
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
