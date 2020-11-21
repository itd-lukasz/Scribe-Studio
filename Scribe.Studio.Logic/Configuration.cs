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
            //foreach(KeyValuePair<string, object> parameter in Parameters)
            //{
            //    fileContent += JsonConvert.SerializeObject(Para);
            //}
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(fileContent);
            sw.Close();
        }

        public static void LoadConfiguration(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
