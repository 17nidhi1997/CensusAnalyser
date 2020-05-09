using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CensusAnalyser
{
    public delegate string DelegateCsvStateDataLoad(CSVFileBuilder builder, string filePath, string header);

    public static string Construct(CSVFileBuilder builder, string filePath, string header)
    {
        try
        {
            int result = builder.StateLoadData(filePath, header);
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

