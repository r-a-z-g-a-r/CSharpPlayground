// See https://aka.ms/new-console-template for more information

using _06_FSTraverserLib;
using TagLib;



bool processForTag(string path)
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
        var a = fs;
    } catch { }
    return true;
}

FSTraverser.Traverse(@"..\..\..\..\00-Resources\fortagging", processForTag);

Console.WriteLine("");

class RasFields
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