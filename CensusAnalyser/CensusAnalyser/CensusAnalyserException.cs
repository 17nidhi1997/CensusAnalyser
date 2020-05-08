using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CensusAnalyser
{
    public enum CensusException
    {
        Wrong_File_Path,
        Wrong_Delimiter,
        IVALID_FILE_EXTENSION,
        FILE_NOT_FOUND,
        Wrong_Header
    }
    public class CensusAnalyserException : Exception
    {

        public string mgs;
        public CensusAnalyserException(string message)
        {
            this.mgs = message;
        }
    }
}
