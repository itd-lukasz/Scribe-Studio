namespace binanceBotNetCore.Logic.BinanceApi
{
    public class Balance
    {
        public string asset { get; set; }
        public decimal free { get; set; }
        public decimal locked { get; set; }
    }
}