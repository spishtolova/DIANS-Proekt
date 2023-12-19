using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtNavigate.Models;
using IronXL;
using OfficeOpenXml;

namespace ArtNavigate.Controllers
{
    public class ArtGaleriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArtGaleries
        public ActionResult Index(string search)
        {
            var galeries = db.ArtGaleries.Where(x => x.Name.Contains(search) || x.Adress.Contains(search) || x.City.Contains(search)  || search == null).ToList();
            return View(galeries);
        }
        public ActionResult IndexEnglish(string search)
        {
            var galeries = db.ArtGaleries.Where(x => x.NameEnglish.Contains(search) || x.AdressEnglish.Contains(search) || x.CityEnglish.Contains(search) || search == null).ToList();
            return View(galeries);
        }
        public ActionResult Help()
        {
            
            return View();
        }
        public ActionResult HelpEnglish()
        {

            return View();
        }

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Process the Excel file and import data into the database
                ImportDataFromExcel(file.InputStream);

                ViewBag.Message = "Import successful";
            }
            else
            {
                ViewBag.Message = "No file selected";
            }

            return View();
        }

        private void ImportDataFromExcel(Stream stream)
        {
            // Use EPPlus to read data from Excel
            using (var package = new ExcelPackage(stream))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets[0]; 

                // Iterate through rows and import data into the database
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    ArtGalery artGalery = new ArtGalery
                    {
                        Name = worksheet.Cells[row, 2].Value.ToString(),
                        Adress = worksheet.Cells[row, 4].Value.ToString(),
                        City= worksheet.Cells[row, 5].Value.ToString(),
                        Latitude = float.Parse(worksheet.Cells[row, 6].Value.ToString()) ,
                        Longtitude = float.Parse(worksheet.Cells[row, 7].Value.ToString()),
                        Description = worksheet.Cells[row, 8].Value.ToString(),
                        NameEnglish = worksheet.Cells[row, 9].Value.ToString(),
                        AdressEnglish = worksheet.Cells[row, 10].Value.ToString(),
                        CityEnglish = worksheet.Cells[row, 11].Value.ToString(),

                    };

                    // Save the product to the database (you need to implement this)
                    db.ArtGaleries.Add(artGalery);
                    db.SaveChanges();
                }
            }
        }

        


        // GET: ArtGaleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtGalery artGalery = db.ArtGaleries.Find(id);
            if (artGalery == null)
            {
                return HttpNotFound();
            }
            return View(artGalery);
        }
        public ActionResult DetailsEnglish(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtGalery artGalery = db.ArtGaleries.Find(id);
            if (artGalery == null)
            {
                return HttpNotFound();
            }
            return View(artGalery);
        }

        // GET: ArtGaleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtGaleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Adress,City,Description,Latitude,Longtitude")] ArtGalery artGalery)
        {
            if (ModelState.IsValid)
            {
                db.ArtGaleries.Add(artGalery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artGalery);
        }

        // GET: ArtGaleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtGalery artGalery = db.ArtGaleries.Find(id);
            if (artGalery == null)
            {
                return HttpNotFound();
            }
            return View(artGalery);
        }

        // POST: ArtGaleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Adress,City,Description,Latitude,Longtitude")] ArtGalery artGalery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artGalery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artGalery);
        }

        // GET: ArtGaleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtGalery artGalery = db.ArtGaleries.Find(id);
            if (artGalery == null)
            {
                return HttpNotFound();
            }
            return View(artGalery);
        }

        // POST: ArtGaleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtGalery artGalery = db.ArtGaleries.Find(id);
            db.ArtGaleries.Remove(artGalery);
            
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
