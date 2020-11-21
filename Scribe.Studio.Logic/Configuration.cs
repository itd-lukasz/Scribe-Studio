using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public static class Configuration
    {
        public static List<KeyValuePair<string, object>> Parameters;

        public static void SaveConfiguration(string fileName)
        {
            string fileContent = "";
            fileContent = JsonConvert.SerializeObject(Parameters);
            
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(fileContent);
            sw.Close();
        }

        public static void LoadConfiguration(string fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string fileContent = sr.ReadToEnd();
                sr.Close();
                Parameters = JsonConvert.DeserializeObject<List<KeyValuePair<string, object>>>(fileContent);
            }
            catch(Exception exc)
            {
                Parameters = new List<KeyValuePair<string, object>>();
                throw exc;
            }
        }
    }
}
