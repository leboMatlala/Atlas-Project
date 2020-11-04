using MongoDB.Driver;
using MongoDBCluster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDBCluster.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            // TODO: Add insert logic here
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.students_collection =
                Models.MongoHelper.database.GetCollection<Models.Student>("students");

            var filter = Builders<Models.Student>.Filter.Ne("_id","");
            var results = Models.MongoHelper.students_collection.Find(filter).ToList();


            return View(results);
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.students_collection =
                Models.MongoHelper.database.GetCollection<Models.Student>("students");

            var filter = Builders<Models.Student>.Filter.Eq("_id", id);
            var results = Models.MongoHelper.students_collection.Find(filter).FirstOrDefault();
            return View(results);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.students_collection =
                    Models.MongoHelper.database.GetCollection<Models.Student>("students");

                //create the object ID
                Object id = GenerateRandomID(24);

                //create on the database
                Models.MongoHelper.students_collection.InsertOneAsync(new Models.Student {

                    _id = id,
                    firstname = collection["firstname"],
                    lastname = collection["lastname"],
                    emailAddress = collection["emailAddress"]

                }) ;
                


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static Random random = new Random();
        private object GenerateRandomID(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray,v).Select(s=>s[random.Next(s.Length)]).ToArray());
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            // TODO: Add insert logic here
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.students_collection =
                Models.MongoHelper.database.GetCollection<Models.Student>("students");

            var filter = Builders<Models.Student>.Filter.Eq("_id", id);
            var results = Models.MongoHelper.students_collection.Find(filter).FirstOrDefault();


            return View(results);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.students_collection =
                    Models.MongoHelper.database.GetCollection<Models.Student>("students");

                var filter = Builders<Models.Student>.Filter.Eq("_id", id);
                var update = Builders<Models.Student>.Update
                    .Set("firstname", collection["firstname"])
                    .Set("lastname", collection["lastname"])
                    .Set("emailAddress", collection["emailAddress"]);

                var results = Models.MongoHelper.students_collection.UpdateOneAsync(filter,update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.students_collection =
                Models.MongoHelper.database.GetCollection<Models.Student>("students");

            var filter = Builders<Models.Student>.Filter.Eq("_id", id);
            var results = Models.MongoHelper.students_collection.Find(filter).FirstOrDefault();
            return View(results);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.students_collection =
                    Models.MongoHelper.database.GetCollection<Models.Student>("students");

                var filter = Builders<Models.Student>.Filter.Eq("_id", id);

                var results = Models.MongoHelper.students_collection.DeleteOneAsync(filter);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
