namespace MusicApp.Media
{

        public class ChartList
        {
            public Country[] countries { get; set; }
            public Global global { get; set; }
        }

        public class Global
        {
            public Genre[] genres { get; set; }
        }

        public class Genre
        {
            public string id { get; set; }
            public string listid { get; set; }
            public string name { get; set; }
            public string urlPath { get; set; }
            public int count { get; set; }
        }

        public class Country
        {
            public string id { get; set; }
            public string listid { get; set; }
            public string momentum_listid { get; set; }
            public string name { get; set; }
            public City[] cities { get; set; }
            public Genre1[] genres { get; set; }
        }

        public class City
        {
            public string id { get; set; }
            public string name { get; set; }
            public string countryid { get; set; }
            public string listid { get; set; }
        }

        public class Genre1
        {
            public string id { get; set; }
            public string countryid { get; set; }
            public string listid { get; set; }
            public string name { get; set; }
            public string urlPath { get; set; }
            public int count { get; set; }
        }


}
