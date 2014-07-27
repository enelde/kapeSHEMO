using SHEMO.Models;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SHEMO.Models;

namespace SHEMO.Controllers
{
    public class WISATAsController : Controller
    {
        private kape_SHEMOEntities db = new kape_SHEMOEntities();

        private IEnumerable<WISATA> GetAllDataWisata()
        {
            IEnumerable<WISATA> results = from b in db.WISATAs
                                          select b;
            return results;
        }

        // GET: WISATAs
        public ActionResult Index()
        {
            return View(db.WISATAs.ToList());
        }

        // GET: WISATAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WISATA wISATA = db.WISATAs.Find(id);
            if (wISATA == null)
            {
                return HttpNotFound();
            }
            return View(wISATA);
        }

        // GET: WISATAs/Create
        public ActionResult Create()
        {
            IEnumerable<WISATA> wisata = GetAllDataWisata();

            int counter = 0;
            foreach(var temp in wisata)
            {
                counter = temp.ID_WISATA;
            }

            counter++;

            ViewBag.counter = counter;
            return View();
        }

        // POST: WISATAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_WISATA,ID_TOP_WISATA,ID_KATEGORI_WISATA,NAMA_WISATA,LOKASI_WISATA,TELEPON_WISATA,DESKRIPSI_WISATA,LATITUDE_WISATA,LONGITUDE_WISATA")] WISATA wISATA)
        {
            if (ModelState.IsValid)
            {
                db.WISATAs.Add(wISATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wISATA);
        }

        // GET: WISATAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WISATA wISATA = db.WISATAs.Find(id);
            if (wISATA == null)
            {
                return HttpNotFound();
            }
            return View(wISATA);
        }

         //POST: WISATAs/Edit/5
         //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_WISATA,ID_TOP_WISATA,ID_KATEGORI_WISATA,NAMA_WISATA,LOKASI_WISATA,TELEPON_WISATA,DESKRIPSI_WISATA,LATITUDE_WISATA,LONGITUDE_WISATA")] WISATA wISATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wISATA).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wISATA);
        }

        // GET: WISATAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WISATA wISATA = db.WISATAs.Find(id);
            if (wISATA == null)
            {
                return HttpNotFound();
            }
            return View(wISATA);
        }

        // POST: WISATAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WISATA wISATA = db.WISATAs.Find(id);
            db.WISATAs.Remove(wISATA);
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
