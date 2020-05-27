using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    class StateCensusAnalyser
    {
        public static int CSVLoadData(string filePath)
        {
            var line = File.ReadLines(filePath);
            string[] data = line.ToArray();
            return data.Length;
        }
    }
}
