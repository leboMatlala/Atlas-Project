using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDBCluster.Models
{
    public class Student
    {
        public Object _id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string emailAddress { get; set; }

    }
}