using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtNavigate.Models;

namespace ArtNavigate.Controllers
{
    public class ArtPiecesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArtPieces page
        public ActionResult Index()
        {
            return View(db.ArtPieces.ToList());
        }

        // GET: ArtPieces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtPieces artPieces = db.ArtPieces.Find(id);
            if (artPieces == null)
            {
                return HttpNotFound();
            }
            return View(artPieces);
        }

        // GET: ArtPieces/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: ArtPieces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,nameEnglish,imageURL,artistName")] ArtPieces artPieces)
        {
            if (ModelState.IsValid)
            {
                db.ArtPieces.Add(artPieces);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artPieces);
        }

        // GET: ArtPieces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtPieces artPieces = db.ArtPieces.Find(id);
            if (artPieces == null)
            {
                return HttpNotFound();
            }
            return View(artPieces);
        }

        // POST: ArtPieces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,nameEnglish,imageURL,artistName")] ArtPieces artPieces)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artPieces).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artPieces);
        }

        // GET: ArtPieces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtPieces artPieces = db.ArtPieces.Find(id);
            if (artPieces == null)
            {
                return HttpNotFound();
            }
            return View(artPieces);
        }

        // POST: ArtPieces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtPieces artPieces = db.ArtPieces.Find(id);
            db.ArtPieces.Remove(artPieces);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddGalery(int id)
        {
            GaleryArtPiece model = new GaleryArtPiece();
            model.artPieceId = id;
            model.artPieces = db.ArtPieces.Find(id);
            model.artGalery = db.ArtGaleries.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddGalery(GaleryArtPiece model)
        {
            var gakeries = db.ArtGaleries.Find(model.artGaleriyId);
            var pieces = db.ArtPieces.Find(model.artPieceId);
            gakeries.artPieces.Add(pieces);
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
