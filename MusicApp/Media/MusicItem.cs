using System;
using System.Collections.Generic;

namespace MusicApp.Media
{
    public class MusicItem
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Images Images { get; set; }
        public string Hub { get; set; }
        public List<Action> Actions { get; set; }
        public string MusicUri { get; set; } // Change here

        private string GetMusicUri()
        {
            try
            {
                var uriAction = Actions?.FirstOrDefault(action => action.type == "uri");
                return uriAction?.uri;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
