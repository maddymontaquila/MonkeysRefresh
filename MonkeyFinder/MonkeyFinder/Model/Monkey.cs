using System;
using System.Globalization;
using System.Text.Json;

namespace MonkeyFinder.Model
{
    public partial class Monkey
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public string Details { get; set; }

        public string Image { get; set; }

        public long Population { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

		public string Video { get; set; }
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
