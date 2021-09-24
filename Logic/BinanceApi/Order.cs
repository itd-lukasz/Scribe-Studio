using binanceBotNetCore.Logic.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binanceBotNetCore.Logic.BinanceApi
{
    public class Order
    {
        public string symbol { get; set; }
        public int orderId { get; set; }
        public int orderListId { get; set; }
        public string clientOrderId { get; set; }
        public Int64 transactTime { get; set; }
        public DateTime TransactionTime { get { return DataFrameUtils.UnixTimeStampToDateTime(Convert.ToDouble(transactTime)); } }
        public decimal price { get; set; }
        public decimal origQty { get; set; }
        public decimal executedQty { get; set; }
        public decimal cummulativeQuoteQty { get; set; }
        public string status { get; set; }
        public string timeInForce { get; set; }
        public string type { get; set; }
        public string side { get; set; }
        public dynamic fills { get; set; }
        public decimal Value
        {
            get
            {
                decimal value = 0;
                foreach (var fill in fills)
                {
                    value += (Convert.ToDecimal(fill["price"]) * Convert.ToDecimal(fill["qty"])) + Convert.ToDecimal(fill["commission"]);
                }
                return value;
            }
        }

        public void RefreshStatus()
        {
            if (status != "FILLED")
            {
                Order order = BinanceApi.GetOrder(symbol, orderId.ToString());
                status = order.status;
                fills = order.fills;
            }
        }
    }
}
