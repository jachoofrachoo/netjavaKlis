using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Application
{

    public class WeatherData
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string MainCondition { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public double Temperature { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public double WindSpeed { get; set; }
        public double Pressure { get; set; }
    }

    internal class WeatherInfo
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class weather
        {
            public string main { get; set; }
            public string descripion { get; set; }
            public string icon { get; set; }
        }

        public class main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
        }

        public class wind
        {
            public double speed { get; set; }
        }

        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }
        }

        public class root
        {
            public coord coord { get; set; }
            public List<weather> weather { get; set;}
            public main main { get; set; }
            public wind wind { get; set; }
            public sys sys { get; set; }
        }

    }
}
