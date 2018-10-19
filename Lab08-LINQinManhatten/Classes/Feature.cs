using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_LINQinManhatten.Classes
{
    class Feature
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("properties")]
        public Properties properties { get; set; }
    }
}
