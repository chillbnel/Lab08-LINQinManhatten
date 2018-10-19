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
            JsonConversion();
        }

        /// <summary>
        /// Method deserializes a JSON file and then filters the data
        /// </summary>
        static void JsonConversion()
        {
            string path = "../../../data.json";
            string text = "";
            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            Manhatten data = JsonConvert.DeserializeObject<Manhatten>(text);
        
            Console.WriteLine("=========== All Neighborhoods ===========");
            var neighborhoods = data.features.Select(x => x).Select(x => x.properties).Select(x => x.neighborhood);
            foreach (var item in neighborhoods)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========== All Neighborhoods That Don't Have Blank ===========");
            var neighborhoodsNoBlanks = neighborhoods.Where(x => x != "");
            foreach (var item in neighborhoodsNoBlanks)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========== All Neighborhoods That Don't Have Duplicates ===========");
            var neighborhoodsNoDuplicates = neighborhoodsNoBlanks.Select(x => x).Distinct();
            foreach (var item in neighborhoodsNoDuplicates)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========== All Filters in One ===========");
            var neighborhoodsAllFilters = data.features.Select(x => x).Select(x => x.properties).Select(x => x.neighborhood)
                                                       .Where(x => x != "")       
                                                       .Select(x => x).Distinct();
            foreach (var item in neighborhoodsAllFilters)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========== LINQ Query ===========");
            var neighborhoodsNoBlanksLINQQuery = from hood in neighborhoods
                                                 where hood != ""
                                                 select hood;

            foreach (var item in neighborhoodsNoBlanksLINQQuery)
            {
                Console.WriteLine(item);
            }
        }
    }
}
