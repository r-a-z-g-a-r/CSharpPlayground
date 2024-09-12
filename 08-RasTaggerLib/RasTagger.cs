using _06_FSTraverserLib;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace _08_RasTaggerLib
{
    public class RasFields
    {
        #region Static Methods
        public static string StandardFieldsOrdered(string delimiter)
        {
            return "Title" + delimiter + "Track" + delimiter + "TrackCount" + delimiter + "Artists" + delimiter + "Album" + delimiter + "AlbumArtist" + delimiter + "Year" + delimiter + "Genres" + delimiter + "Disc" + delimiter + "DiscCount";
        }
        #endregion
        public string Path { get; set; }
        public string Title { get; set; }
        public uint Track { get; set; }
        public uint TrackCount { get; set; }
        public string[] Artists { get; set; }
        public string Album { get; set; }
        public string[] AlbumArtist { get; set; }
        public uint Year { get; set; }
        public string[] Genres { get; set; }
        public uint Disc { get; set; }
        public uint DiscCount { get; set; }

        #region Public Methods
        public string StandardOrdered(string delimiter)
        {
            string stringArryDelimiter = ", ";
            return Title + delimiter + Track + delimiter + TrackCount + delimiter + String.Join(stringArryDelimiter, Artists) + delimiter + Album + delimiter + String.Join(stringArryDelimiter, AlbumArtist) + delimiter + Year.ToString() + delimiter + String.Join(stringArryDelimiter, Genres) + delimiter + Disc.ToString() + delimiter + DiscCount.ToString();
        }
        public bool Update(string propertyName, object newVal)
        {
            var tfile = TagLib.File.Create(Path);
            var prop = tfile.Tag.GetType().GetProperty(propertyName);
            if (prop != null)
            {
                prop.SetValue(tfile.Tag, newVal);
                tfile.Save();
            }
            tfile.Dispose();
            return true;
        }
        #endregion

    }

    class RasTaggerClass
    {
        #region Fields
        string Path = null;
        Func<RasFields, bool> RasFieldsProcessor = null;
        #endregion

        #region Ctor
        public RasTaggerClass(string path, Func<RasFields, bool> processor)
        {
            Path = path;
            RasFieldsProcessor = processor;
        }
        #endregion

        #region Public Methods
        public int Run()
        {
            return FSTraverser.Traverse(Path, processForRasFields);
        }
        #endregion

        #region Private Methods
        private bool processForRasFields(string path)
        {
            TagLib.File? tfile = null;
            try
            {
                tfile = TagLib.File.Create(path);
                RasFields fs = new RasFields()
                {
                    Path = path,
                    Title = tfile.Tag.Title,
                    Track = tfile.Tag.Track,
                    TrackCount = tfile.Tag.TrackCount,
                    Artists = tfile.Tag.Performers,
                    Album = tfile.Tag.Album,
                    AlbumArtist = tfile.Tag.AlbumArtists,
                    Year = tfile.Tag.Year,
                    Genres = tfile.Tag.Genres,
                    Disc = tfile.Tag.Disc,
                    DiscCount = tfile.Tag.DiscCount
                };
                tfile.Dispose();
                return RasFieldsProcessor(fs);
            }
            catch { }
            return true;
        }
        #endregion
    }

    static public class RasTagger
    {        
        public static int traverse (string path, Func<RasFields, bool> rasFieldsProcessor)
        {
            var processingClass = new RasTaggerClass(path, rasFieldsProcessor);
            return processingClass.Run();
        }
    }
}
