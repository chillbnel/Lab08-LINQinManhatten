using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_LINQinManhatten.Classes
{
    class Manhatten
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("features")]
        public List<Feature> features { get; set; }
    }
}
