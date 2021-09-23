using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.BinanceApi
{
    public class ExchangeSymbol
    {
        public string Symbol { get; set; }
        public decimal QuantityStep { get; set; }
        public int QuantityDecimalPlaces
        {
            get
            {
                string decimal_places = QuantityStep.ToString();
                decimal_places = decimal_places.Remove(0, 2);
                int res = 1;
                while(!decimal_places.StartsWith("1"))
                {
                    decimal_places = decimal_places.Remove(0, 1);
                    res++;
                }
                return res;
            }
        }
        public decimal Commission { get; set; }
        public decimal PriceStep { get; set; }
        public int PriceDecimalPlaces
        {
            get
            {
                string decimal_places = PriceStep.ToString();
                decimal_places = decimal_places.Remove(0, 2);
                int res = 1;
                while (!decimal_places.StartsWith("1"))
                {
                    decimal_places = decimal_places.Remove(0, 1);
                    res++;
                }
                return res;
            }
        }

        public override string ToString()
        {
            return string.Format($"Symbol: {Symbol}, Step: {QuantityStep}, Qty Decimal Places: {QuantityDecimalPlaces}, Price Decimal Places: {PriceDecimalPlaces}");
        }
    }
}
