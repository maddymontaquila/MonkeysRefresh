using System;
using System.Globalization;
using System.Text.Json;

namespace MonkeyFinder.Model
{
    public partial class Monkey
    {
        //[JsonProperty("Name")]
        public string Name { get; set; }

        //[JsonProperty("Location")]
        public string Location { get; set; }

        //[JsonProperty("Details")]
        public string Details { get; set; }

        //[JsonProperty("Image")]
        public string Image { get; set; }

        //[JsonProperty("Population")]
        public long Population { get; set; }

        //[JsonProperty("Latitude")]
        public double Latitude { get; set; }

        //[JsonProperty("Longitude")]
        public double Longitude { get; set; }
    }
    
    public partial class Monkey
    {
        public static Monkey[] FromJson(string json) => JsonSerializer.Deserialize<Monkey[]>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this Monkey[] self) => JsonSerializer.Serialize(self);
    }
}
