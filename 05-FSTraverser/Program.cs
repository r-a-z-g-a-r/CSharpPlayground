// See https://aka.ms/new-console-template for more information
using _05_FSTraverser;

bool processFileTrivial(string path)
{
    Console.WriteLine(path);
    return true;
}

FSTraverser.Traverse(@"C:\Windows", processFileTrivial);
