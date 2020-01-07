using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tFX_tool.Models;

namespace tFX_tool.Controllers
{
    public class TfxtoolsController : Controller
    {
        // GET: Tfxtools
        public ActionResult Index() //controller fxn home page for tfx tools
        {
            using (TFXToolswebconfig db = new TFXToolswebconfig())
            {
                return View(db.EquityTables.ToList());
            }
        }

        // GET: Tfxtools/Details/5
        public ActionResult Details(int id) //details view to edit individual record by id
        {
            using (TFXToolswebconfig db = new TFXToolswebconfig())
            {
                return View(db.EquityTables.Where(x => x.Id == id).FirstOrDefault()); ;
            }

        }

        public ActionResult DetailsAll() // controller fxn for equity table without  crud
        {
            using (TFXToolswebconfig db = new TFXToolswebconfig())
            {
                return View(db.EquityTables.ToList());
            }

        }

        // GET: Tfxtools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tfxtools/Create
        [HttpPost]
        public ActionResult Create(EquityTable equity)
        {
            try
            {
                // TODO: Add insert logic here
                using (TFXToolswebconfig db = new TFXToolswebconfig())
                { 
                    db.EquityTables.Add(equity);
                    db.SaveChanges();
                }                         
            return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tfxtools/Edit/5
        public ActionResult Edit(int id)
        {
            using (TFXToolswebconfig db = new TFXToolswebconfig())
            {
                return View(db.EquityTables.Where(x => x.Id == id).FirstOrDefault()); ;
            }
        }

        // POST: Tfxtools/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EquityTable equityTable)
        {
            try
            {
                // TODO: Add update logic here
                using (TFXToolswebconfig db = new TFXToolswebconfig())
                {
                    db.Entry(equityTable).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");   
            }
            catch
            {
                return View();
            }
        }

        // GET: Tfxtools/Delete/5
        public ActionResult Delete(int id)
        {
            using (TFXToolswebconfig db = new TFXToolswebconfig())
            {
                return View(db.EquityTables.Where(x => x.Id == id).FirstOrDefault()); ;
            }
        }

        // POST: Tfxtools/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EquityTable equityTable)
        {
            try
            {
                // TODO: Add delete logic here
                equityTable = (db.EquityTables.Where(x => x.Id == id).FirstOrDefault());
                db.EquityTables.Remove(equityTable);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
            catch
            {
                return View();
            }
        }
    }
}
