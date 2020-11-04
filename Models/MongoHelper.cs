using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace MongoDBCluster.Models
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }

        public static string MongoConnection = "mongodb+srv://sibongileUser:EpVICGg1d4IVtxmg@ejoobi-cluster.59zlm.azure.mongodb.net/session_stateDB?retryWrites=true&w=majority";
        
        public static string MongoDatabase = "session_stateDB";

        public static IMongoCollection<Models.Student> students_collection { get; set; }

        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);

            }catch(Exception)
            {

                throw;
            }
        }
    }
}