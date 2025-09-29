namespace AbySalto.Junior.Models.Currencies
{
    public class ExchangeRate
    {
        public int ExchangeRateId { get; set; }
        public int FromCurrencyId { get; set; }
        public Currency FromCurrency { get; set; }
        public int ToCurrencyId { get; set; }
        public Currency ToCurrency { get; set; }
        public decimal Rate { get; set; }
    }
}
