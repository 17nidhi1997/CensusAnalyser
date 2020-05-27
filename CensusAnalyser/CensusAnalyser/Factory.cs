using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    class Factory
    {
        public CSVFileBuilder GetObjectCSVStateCensus()
        {
            return new CSVStateCensus();
        }
    }
}