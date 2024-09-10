using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05_FSTraverser
{
    class FSTraverser
    {
        private static int ProcessDirectory(string path, Func<string, bool> processor)
        {
            int fileCnt = 0;
            try
            {
                foreach (string entry in Directory.EnumerateFileSystemEntries(path))
                {
                    if (Directory.Exists(entry))
                    {
                        ProcessDirectory(entry, processor);
                        continue;
                    }
                    if (/*File.Exists(entry) && */!processor(entry))
                    {
                        return fileCnt;
                    }
                    fileCnt++;
                }
            } catch { }
            return fileCnt;
        }
        static public int Traverse (string path, Func<string, bool> processor)
        {
            int fileCnt = 0;
            if (!Directory.Exists(path))
            {
                return fileCnt;
            }
            fileCnt += ProcessDirectory(path, processor);
            return fileCnt;
        }
    }
}
