namespace MusicApp.Media
{
    public class Charts
    {

        public class Rootobject
        {
            public Properties properties { get; set; }
            public Track[] tracks { get; set; }
        }

        public class Properties
        {
        }

        public class Track
        {
            public string layout { get; set; }
            public string type { get; set; }
            public string key { get; set; }
            public string title { get; set; }
            public string subtitle { get; set; }
            public Share share { get; set; }
            public Images images { get; set; }
            public Hub hub { get; set; }
            public Artist[] artists { get; set; }
            public string url { get; set; }
            public Highlightsurls highlightsurls { get; set; }
            public Properties1 properties { get; set; }
        }

        public class Share
        {
            public string subject { get; set; }
            public string text { get; set; }
            public string href { get; set; }
            public string image { get; set; }
            public string twitter { get; set; }
            public string html { get; set; }
            public string avatar { get; set; }
            public string snapchat { get; set; }
        }

        public class Images
        {
            public string background { get; set; }
            public string coverart { get; set; }
            public string coverarthq { get; set; }
            public string joecolor { get; set; }
        }

        public class Hub
        {
            public string type { get; set; }
            public string image { get; set; }
            public Action[] actions { get; set; }
            public Option[] options { get; set; }
            public bool _explicit { get; set; }
            public string displayname { get; set; }
        }

        public class Action
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public string uri { get; set; }
        }

        public class Option
        {
            public string caption { get; set; }
            public Action1[] actions { get; set; }
            public Beacondata beacondata { get; set; }
            public string image { get; set; }
            public string type { get; set; }
            public string listcaption { get; set; }
            public string overflowimage { get; set; }
            public bool colouroverflowimage { get; set; }
            public string providername { get; set; }
        }

        public class Beacondata
        {
            public string type { get; set; }
            public string providername { get; set; }
        }

        public class Action1
        {
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class Highlightsurls
        {
            public string artisthighlightsurl { get; set; }
            public string relatedhighlightsurl { get; set; }
            public string trackhighlighturl { get; set; }
        }

        public class Properties1
        {
        }

        public class Artist
        {
            public Follow follow { get; set; }
            public string alias { get; set; }
            public string id { get; set; }
            public string adamid { get; set; }
        }

        public class Follow
        {
            public string followkey { get; set; }
        }

    }
}
