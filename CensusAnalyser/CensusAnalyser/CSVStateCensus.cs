using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using LumenWorks.Framework.IO.Csv;

namespace CensusAnalyser
{
    class CSVStateCensus
    {
        public static int StateLoadData(string filePath)
        {
            int numberOfRecord = 0;
            try
            {
                CsvReader csvRecords = new CsvReader(new StreamReader(filePath), true);
                int fieldCount = csvRecords.FieldCount;
                string[] headers = csvRecords.GetFieldHeaders();
                char delimete = csvRecords.Delimiter;
                //// string ArrayList
                List<string[]> record = new List<string[]>();
                foreach (var line in File.ReadLines(filePath))
                {
                    string[] tempRecord = new string[fieldCount];
                    csvRecords.CopyCurrentRecordTo(tempRecord);
                    record.Add(tempRecord);
                    numberOfRecord++;
                }
                return numberOfRecord;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(CensusException.Wrong_File_Path + "");
            }
        }
        public static void CheckDelimiter(string filePath, string header)
        {
            string line1 = File.ReadAllText(filePath);
            var file_total = File.ReadLines(filePath);
            string[] line_element = file_total.ToArray();
            if (!line_element[0].Contains(header))
            {
                throw new CensusAnalyserException(CensusException.Wrong_Delimiter + "");
            }
            else
            {
                Console.WriteLine("right ");
            }
            if (!line1.Contains(";"))
            {
                throw new CensusAnalyserException(CensusException.Wrong_Delimiter + "");
            }
        }
    }
}
