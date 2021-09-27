using binanceBotNetCore.Logic.BinanceApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.Helpers
{
    public static class GlobalStore
    {
        public static List<ExchangeSymbol> Symbols { get; set; }
        public static Account Account { get; set; }
        public static int Units { get; set; }
        public static decimal Percent { get; set; }
    }
}
