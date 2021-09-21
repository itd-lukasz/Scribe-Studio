namespace binanceBotNetCore.Logic.Helpers
{
    public class WalletPosition
    {
        public string Currency { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Value { get { return Quantity * Price; } }
    }
}