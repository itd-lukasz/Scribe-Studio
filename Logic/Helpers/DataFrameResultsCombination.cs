using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.Helpers
{
    public class DataFrameResultsCombination
    {
        public string symbol { get; set; }
        public string binary { get; set; }
        public string shouldBuy { get; set; }
        public string oneMinute { get; set; }
        public string twoMinute { get; set; }
        public string threeMinute { get; set; }
        public string fourMinute { get; set; }
        public string fiveMinute { get; set; }
        public int count { get; set; }
    }
}
