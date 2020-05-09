using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace CensusAnalyser
{

    public class CSVStateCensus : CSVFileBuilder
    {

        public int StateLoadData(string filePath, string header, string delimeter = ",")
        {
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


            int k = 1;
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = line_element[0].Split(",");
            if (key.Length < 2)
            {
                throw new CensusAnalyserException(CensusException.Wrong_Delimiter + "");
            }

            for (int i = 1; i < line_element.Length; i++)
            {
                string[] value = line_element[i].Split(",");
                Dictionary<string, string> subMap = new Dictionary<string, string>()
               {
                   { key[0], value[0] },
                   { key[1], value[1] },
                   { key[2], value[2] },
                   { key[3], value[3] },
               };

                map.Add(k, subMap);
                k++;
            }

            foreach (var data in map)
            {
                Console.WriteLine("{");
                foreach (var data1 in data.Value)
                {
                    Console.WriteLine(data1);
                }

                Console.WriteLine("},");
            }

            return map.Count;
        }

    }
}