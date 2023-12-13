using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using MusicApp.Media;

namespace MusicApp.Media
{
    [TestClass]
    public class MediaDataTests
    {
        [TestMethod]
        public void MediaData_NullTracksArray_ReturnsNull()
        {
            var mediaData = new MediaData { tracks = null };
            Assert.IsNull(mediaData.tracks);
        }

        [TestMethod]
        public void MediaData_EmptyTracksArray_ReturnsEmptyArray()
        {
            var mediaData = new MediaData { tracks = new Track[] { } };
            Assert.AreEqual(0, mediaData.tracks?.Length);
        }
    }

    [TestClass]
    public class TrackTests
    {
        [TestMethod]
        public void Track_NullProperties_ReturnsNull()
        {
            var track = new Track();
            Assert.IsNull(track.layout);
            Assert.IsNull(track.type);
        }

        [TestMethod]
        public void Track_EmptyStringProperties_ReturnsEmptyString()
        {
            var track = new Track { layout = "", type = "" };
            Assert.IsTrue(string.IsNullOrEmpty(track.layout));
            Assert.IsTrue(string.IsNullOrEmpty(track.type));
        }
    }
}
