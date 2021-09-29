using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.BinanceApi
{
    public class Trade
    {
        public string symbol { get; set; }
        public long id { get; set; }
        public long orderId { get; set; }
        public int orderListId { get; set; }
        public decimal price { get; set; }
        public decimal qty { get; set; }
        public decimal quoteQty { get; set; }
        public decimal commission { get; set; }
        public string commissionAsset { get; set; }
        public long time { get; set; }
        public string isBuyer { get; set; }
        public string isMaker { get; set; }
        public string isBestMatch { get; set; }
    }
}
