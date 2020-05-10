using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using ChoETL;

namespace CensersAnalyser
{
    public class utility
    {
        // Method Convert Csv file to Json file.
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
        // Method for sorting json File.
        public static JArray SortCensus(string path)
        {
            string json = File.ReadAllText(path);
            JArray stateArrary = JArray.Parse(json);
            for (int i = 0; i < stateArrary.Count - 1; i++)
            {
                for (int j = 0; j < stateArrary.Count - i - 1; j++)
                {
                    if (stateArrary[j]["State"].ToString().CompareTo(stateArrary[j + 1]["State"].ToString()) > 0)
                    {
                        var tamp = stateArrary[j + 1];
                        stateArrary[j + 1] = stateArrary[j];
                        stateArrary[j] = tamp;
                    }
                }
            }

            return stateArrary;
        }
    }
}