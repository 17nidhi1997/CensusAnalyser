using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using ChoETL;

namespace CensersAnalyser
{
    public class utility
    {
        //// Method Convert Csv file to Json file.
        public void ConvertCsvFileToJsonObject(string cSVFile, string jsonFile)
        {
            string re = File.ReadAllText(cSVFile);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(re).WithFirstLineHeader())
            {
                using var w = new ChoJSONWriter(sb);
                w.Write(p);
            }
            File.WriteAllText(jsonFile, sb.ToString());
        }

        //// Method for sorting json File.       
        public static JArray SortCensus(string path, string key)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count - 1; i++)
            {
                for (int j = 0; j < stateArrary.Count - i - 1; j++)
                {
                    if ((int)stateArrary[j][key] > (int)stateArrary[j + 1][key])
                    {
                        var tamp = stateArrary[j + 1];
                        stateArrary[j + 1] = stateArrary[j];
                        stateArrary[j] = tamp;
                    }
                }
            }
            return stateArrary;
        }
        //// Print the json file.      
        public static void PrintJsonFile(string path)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count; i++)
            {
                Console.WriteLine(stateArrary[i]);
            }
        }

        //// Return The first element  state name of Json Array.        
        public static string FirstElementNameOfJsonArray(string path, string elementName)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            return stateArrary[0][elementName].ToString();
        }

        //// Return The first element  state name of Json Array.       
        public object LastElementNameOfJsonArray(string path, string elementName)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            int length = stateArrary.Count;
            return stateArrary[length - 1][elementName];
        }
    }
}