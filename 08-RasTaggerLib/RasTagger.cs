using _06_FSTraverserLib;
using System;
using System.Diagnostics;
using System.IO;

namespace _08_RasTaggerLib
{
    public class RasFields
    {
        public string Title { get; set; }
        public uint Track { get; set; }
        public uint TrackCount { get; set; }
        public string[] Artists { get; set; }
        public string Album { get; set; }
        public string AlbumArtist { get; set; }
        public uint Year { get; set; }
        public string[] Genres { get; set; }
        public uint Disc { get; set; }
        public uint DiscCount { get; set; }
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
                    Title = tfile.Tag.Title,
                    Track = tfile.Tag.Track,
                    TrackCount = tfile.Tag.TrackCount,
                    Artists = tfile.Tag.AlbumArtists,
                    Album = tfile.Tag.Album,
                    AlbumArtist = tfile.Tag.FirstAlbumArtist,
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
        static int traverse (string path, Func<RasFields, bool> rasFieldsProcessor)
        {
            var processingClass = new RasTaggerClass(path, rasFieldsProcessor);
            return processingClass.Run();
        }
    }
}
