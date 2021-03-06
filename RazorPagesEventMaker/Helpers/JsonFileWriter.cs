﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToJson(List<Event> events, string filePath)
        {
            string output = JsonConvert.SerializeObject(events);
            File.WriteAllText(filePath, output);
        }

    }
}
