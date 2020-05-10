using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using LumenWorks.Framework.IO.Csv;

namespace CensusAnalyser
{

    public class CSVStateCensusDAO : CSVFileBuilder
    {
        string header;
        string delimeter;
        string filepath;
        public CSVStateCensusDAO()
        {
        }

        // CsvStates parameterised constructor
        public CSVStateCensusDAO(string filePath, string header, string delimeter = ",")
        {
            this.filepath = filepath;
            this.header = header;
            this.delimeter = delimeter;
        }
        public object StateLoadData(string filePath, string header, string delimeter = ",")
        {
           
            int numberOfRecord = 0;
            var file_total = File.ReadLines(filePath);
            string[] line_element = file_total.ToArray();
            if (!line_element[0].Contains(header))
            {
                throw new CensusAnalyserException(CensusException.Wrong_Header + "");
            }

            else if (!file_total.Contains(";"))
            {
                throw new CensusAnalyserException(CensusException.Wrong_Delimiter + "");
            }
            try
            {
                CsvReader csvRecords = new CsvReader(new StreamReader(filePath), true);
                int fieldCount = csvRecords.FieldCount;
                string[] headers = csvRecords.GetFieldHeaders();
                char delimete = csvRecords.Delimiter;
                // string ArrayList
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

    }
}