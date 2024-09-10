// See https://aka.ms/new-console-template for more information
using _08_RasTaggerLib;
using System.IO;

const string delimiter = "\t";
//const string path = @"..\..\..\..\00-Resources\fortagging";
const string inPath = @"D:\";

StreamWriter outStream = new StreamWriter("Tags.csv");

bool csvEr (RasFields fields)
{
    outStream.WriteLine(fields.StandardOrdered(delimiter));
    return true;
}

outStream.WriteLine(RasFields.StandardFieldsOrdered(delimiter));
RasTagger.traverse(inPath, csvEr);
outStream.Dispose();