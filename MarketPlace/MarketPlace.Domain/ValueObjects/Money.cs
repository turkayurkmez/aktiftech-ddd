using MarketPlace.Domain.Services;

namespace MarketPlace.Domain.ValueObjects
{
    public class Money : IEquatable<Money>
    {
        private static string _currencyCode;
        private static ICurrencyLookup _currencyLookup;

        public decimal Amount { get; set; }

        public Money(decimal amount, string currencyCode, ICurrencyLookup currencyLookup)
        {
            var currency = currencyLookup.FindCurrency(currencyCode);
            if (!currency.InUse)
            {

            }
            if (decimal.Round(amount, currency.DecimalPlaces) != amount)
            {

            }
            Amount = amount;
            Money._currencyLookup = currencyLookup;
            Money._currencyCode = currencyCode;

            //_currencyCode = currencyCode;
            //_currencyLookup = currencyLookup;
        }

        public bool Equals(Money? other)
        {
            if (ReferenceEquals(other, null)) { return false; }
            if (ReferenceEquals(other, this)) { return true; }
            return Amount.Equals(other.Amount);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) { return false; }
            if (ReferenceEquals(obj, this)) { return true; }
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }



        public static bool operator ==(Money left, Money right) => Equals(left, right);

        public static bool operator !=(Money left, Money right) => !Equals(left, right);

        public static Money operator +(Money left, Money right)
        {
            return new Money(left.Amount + right.Amount, Money._currencyCode, Money._currencyLookup);
        }

        public static Money operator -(Money left, Money right) => new Money(left.Amount - right.Amount, Money._currencyCode, Money._currencyLookup);



        /*
        * TL: 5,90 TL
        * EUR: 5.900 
        * $: $5.9
        */
        public static Money FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup) => new Money(amount, currency, currencyLookup);


    }
}
