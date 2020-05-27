using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public interface CSVFileBuilder
    {
       object StateLoadData(string filePath, string header, string delimeter = ",");
    }
}