using binanceBotNetCore.Logic.Helpers;
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
        public Int64 orderId { get; set; }
        public Int64 orderListId { get; set; }
        public string clientOrderId { get; set; }
        public Int64 transactTime { get; set; }
        public Int64 time { get; set; }
        public DateTime TransactionTime
        {
            get
            {
                if (time != null)
                {
                    return DataFrameUtils.UnixTimeStampToDateTime(Convert.ToDouble(time));
                }
                else
                {
                    return DataFrameUtils.UnixTimeStampToDateTime(Convert.ToDouble(transactTime));
                }
            }
        }
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
                if (fills != null)
                {
                    foreach (var fill in fills)
                    {
                        value += (Convert.ToDecimal(fill["price"]) * Convert.ToDecimal(fill["qty"])) + Convert.ToDecimal(fill["commission"]);
                    }
                }
                else
                {
                    value = price * executedQty;
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

        public override string ToString()
        {
            return string.Format($"[{orderId}] Order date: {TransactionTime}, Order value: {Value}, Order side: {side}, Order status: {status}");
        }

        public static void AddMissingOrders(List<Order> orders)
        {
            orders = orders.Where(o => o.status == "FILLED" || o.status == "NEW").ToList();
            for (int a = 0; a < orders.Count; a++)
            {
                if ((orders[a].side == "BUY") && ((a + 1 >= orders.Count) || (orders[a + 1] == null) || (orders[a + 1].side == "BUY")))
                {
                    decimal commission = GlobalStore.Symbols.Where(s => s.Symbol == orders[a].symbol).Select(s => s.Commission).First() * orders[a].executedQty;
                    BinanceApi.CreateOrder(orders[a].symbol, orders[a].executedQty,
                        Math.Round((orders[a].Value + ((orders[a].Value / 100) * GlobalStore.Percent) + commission) / orders[a].executedQty, GlobalStore.Symbols.Where(s => s.Symbol == orders[a].symbol).Select(s => s.PriceDecimalPlaces).First()), "SELL");
                }
            }
        }
    }
}
