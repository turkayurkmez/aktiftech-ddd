namespace MarketPlace.Domain.Services
{
    public interface ICurrencyLookup
    {
        Currency FindCurrency(string currencyCode);
    }

    public class Currency
    {
        public string CurrencyCode { get; set; }
        public bool InUse { get; set; }
        public int DecimalPlaces { get; set; }
        public static Currency None { get; set; } = new Currency() { InUse = false };
    }
}
