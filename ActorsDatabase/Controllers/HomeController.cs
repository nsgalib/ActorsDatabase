using ActorsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActorsDatabase.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var data = db.Actors.SqlQuery("Select * from ActorsTable").ToList();
            return View(data);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Actors.SqlQuery("Select * from ActorsTable where ID=@p0", id).SingleOrDefault();
            return View(data);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Actors collection)
        {
            try
            {
                // TODO: Add insert logic here

                List<object> lst = new List<object>();
                lst.Add(collection.Name);
                lst.Add(collection.Country);
                lst.Add(collection.Age);
                lst.Add(collection.Gender);
                lst.Add(collection.NetWorth);
                lst.Add(collection.Image);
                lst.Add(collection.Info);

                object[] allitems = lst.ToArray();
                int output = db.Database.ExecuteSqlCommand("insert into ActorsTable(Name, Country, Age, Gender, NetWorth, Image, Info) values(@p0, @p1, @p2, @p3, @p4, @p5, @p6)", allitems);

                if(output > 0)
                {
                    ViewBag.msg = "Record added";
                }

                return View();
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Actors.SqlQuery("Select * from ActorsTable where ID=@p0", id).SingleOrDefault();

            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Actors collection)
        {
            try
            {
                // TODO: Add update logic here
                List<object> lst = new List<object>();
                lst.Add(collection.Name);
                lst.Add(collection.Country);
                lst.Add(collection.Age);
                lst.Add(collection.Gender);
                lst.Add(collection.NetWorth);
                lst.Add(collection.Image);
                lst.Add(collection.Info);
                lst.Add(collection.ID);

                object[] allitems = lst.ToArray();
                int output = db.Database.ExecuteSqlCommand("update ActorsTable set Name=@p0, Country=@p1, Age=@p2, Gender=@p3, NetWorth=@p4, Image=@p5, Info=@p6 where ID=@p7", allitems);

                if (output > 0)
                {
                    ViewBag.msg = "Actor ID " + collection.ID + " has been updated";

                }
                return View();
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Actors.SqlQuery("Select * from ActorsTable where ID=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Actors collection)
        {
            try
            {
                // TODO: Add delete logic here
                var actorList = db.Database.ExecuteSqlCommand("Delete from ActorsTable where ID=@p0", id);

                if(actorList != 0)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
