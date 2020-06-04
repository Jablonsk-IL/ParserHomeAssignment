using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentParserEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DAL;

namespace WaycareHomeAssignmentApplication
{
    class Program
    {
        const string path1 = @"C:\Users\Mason\Desktop\Home Assignment Python\accident1.json";
        const string path2 = @"C:\Users\Mason\Desktop\Home Assignment Python\accident2.json";

        /// <summary>
        ///  example code using the parser to index into mongo
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DBAdapter mongoAdapter = new MongoAdapter();
            MainParser mp = new MainParser();

            string content1 = File.ReadAllText(path1);
            string output1 = mp.ParseInput(content1);
            mongoAdapter.Index(output1);

            string content2 = File.ReadAllText(path2);
            string output2 = mp.ParseInput(content2);
            mongoAdapter.Index(output2);
        }
    }
}
