namespace MinimalAPI.Domain.ValueObjects
{
    public record ProductPrice
    {
        public decimal Value { get; }

        public ProductPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be less than 0");

            if (price > 100000)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be more than 100000");

            Value = price;
        }

        public override string ToString() => $"{Value:F2}";
    }
}
