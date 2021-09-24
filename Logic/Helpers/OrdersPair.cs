using binanceBotNetCore.Logic.BinanceApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.Helpers
{
    public class OrdersPair
    {
        public Order FirstOrder { get; set; }
        public Order SecondOrder { get; set; }
    }
}
