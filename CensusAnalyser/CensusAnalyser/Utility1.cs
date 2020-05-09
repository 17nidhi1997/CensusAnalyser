using System;
using System.IO;
using System.Text;
using ChoETL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CensersAnaliserProblem
{
    class utility1
    {

        // Method Convert Csv file to Json file
        public static void ConvertCsvFileToJsonObject(string cSVFile, string jsonFile)
        {
            string reader = File.ReadAllText(cSVFile);
            StringBuilder sb = new StringBuilder();
            using (var value = ChoCSVReader.LoadText(reader).WithFirstLineHeader())
            {
                using var w = new ChoJSONWriter(sb);
                w.Write(value);
            }

            File.WriteAllText(jsonFile, sb.ToString());
        }


        // Method for sorting json File.       
        public static void SortStateCode(string path)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count - 1; i++)
            {
                for (int j = 0; j < stateArrary.Count - i - 1; j++)
                {
                    if (stateArrary[j]["StateCode"].ToString().CompareTo(stateArrary[j + 1]["StateCode"].ToString()) > 0)
                    {
                        var tamp = stateArrary[j + 1];
                        stateArrary[j + 1] = stateArrary[j];
                        stateArrary[j] = tamp;
                    }
                }
            }
            string jsonF = JsonConvert.SerializeObject(stateArrary, Formatting.Indented);
            File.WriteAllText(path, jsonF);
        }

        // Print the json file.      
        public static void PrintJsonFile(string path)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count; i++)
            {
                Console.WriteLine(stateArrary[i]);
            }
        }

        // Return The first element  state name of Json Array.        
        public static string FirstElementNameOfJsonArray(string path, string elementName)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            return stateArrary[0][elementName].ToString();
        }

        // Return The first element  state name of Json Array.       
        public static string LastElementNameOfJsonArray(string path, string elementName)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            int length = stateArrary.Count;
            return stateArrary[length - 1][elementName].ToString();
        }
    }
}