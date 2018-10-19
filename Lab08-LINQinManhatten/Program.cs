using System;
using Lab08_LINQinManhatten.Classes;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Lab08_LINQinManhatten
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void JsonConversion()
        {
            string path = "../../data.json";
            string text = "";
            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            IEnumerable<Properties> brooklynProperties = JsonConvert.DeserializeObject<List<Properties>>(text);

            var someName = brooklynProperties.Where(x => x.neighborhood);


        }
    }
}
