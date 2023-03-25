using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class SignUpController : Controller
    {
        private ZH_DBEntities db = new ZH_DBEntities();

        // GET: SignUp
        public ActionResult Index()
        {
            return View(db.SignUps.ToList());
        }

        // GET: SignUp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignUp signUp = db.SignUps.Find(id);
            if (signUp == null)
            {
                return HttpNotFound();
            }
            return View(signUp);
        }

        // GET: SignUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignUp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,usertype,username,name,password,email,phone_No")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                db.SignUps.Add(signUp);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(signUp);
        }

        // GET: SignUp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignUp signUp = db.SignUps.Find(id);
            if (signUp == null)
            {
                return HttpNotFound();
            }
            return View(signUp);
        }

        // POST: SignUp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,usertype,username,name,password,email,phone_No")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signUp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signUp);
        }

        // GET: SignUp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignUp signUp = db.SignUps.Find(id);
            if (signUp == null)
            {
                return HttpNotFound();
            }
            return View(signUp);
        }

        // POST: SignUp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SignUp signUp = db.SignUps.Find(id);
            db.SignUps.Remove(signUp);
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //private ZH_DBEntities db = new ZH_DBEntities();
        [HttpPost]
        public ActionResult Login(SignUp log)
        {
            var SignUp = db.SignUps.Where(x => x.username == log.username && x.password == log.password).Count();
            if (SignUp > 0)
            {

                return RedirectToAction("aDashborad");

            }
            else
            {

                return View();

            }

        }


        public ActionResult aDashborad()
        {

            return View();
        }



        public ActionResult Dashborad()
        {

            return View();
        }












    }

}
