using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public interface CSVFileBuilder
    {

        public int StateLoadData(string filePath, string header, string delimeter = ",");
    }

}