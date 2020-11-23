using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonFileReader
    {
        public static List<Event> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Event>>(jsonString);
        }

        

    }
}
