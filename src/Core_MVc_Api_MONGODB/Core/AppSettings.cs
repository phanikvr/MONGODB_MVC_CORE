using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_MVc_Api_MONGODB.Core
{
    public class AppSettings
    {
        public MongoConnection MongoConnection { get; set; }

        // changed the names deleberately becaseu, nothing to do with names from  appSettings.dev.json file
        public LoggingSettings LogSettings { get; set; }
    }

    public class MongoConnection
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }

    public class LoggingSettings
    {
        // for the time being i dont want these settings. if you want create properties here and assign them in startup class
    }
}
