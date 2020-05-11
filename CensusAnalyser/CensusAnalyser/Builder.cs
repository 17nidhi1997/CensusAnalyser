using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CensusAnalyser
{
    public delegate string DelegateCsvStateDataLoadDAO(CSVFileBuilder builder, string filePath, string header, string delimeter = ",");
    class Builder
    {
        public static string Construct(CSVFileBuilder builder, string filePath, string header, string delimeter = ",")
        {
            try
            {
                object result = builder.StateLoadData(filePath, header, delimeter);
                return result.ToString();


            }
            catch (CensusAnalyserException ex)

            {
                throw ex;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(CensusException.Wrong_File_Path + "");

            }
        }
    }
}
