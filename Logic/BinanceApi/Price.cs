using System;

namespace binanceBotNetCore.Logic.BinanceApi{

    public class Price
    {
        public string symbol{get;set;}
        public decimal price { get; set; }
        public DateTime time { get; set; }

        public Price()
        {
            this.time = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format($"Symbol: {this.symbol}, Price: {this.price}");
        }
    }
}