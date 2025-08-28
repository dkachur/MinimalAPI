namespace MinimalAPI.Domain.ValueObjects
{
    public record ProductDescription
    {
        public string Value { get; }

        public ProductDescription(string desc)
        {
            if (desc.Length > 1000)
                throw new ArgumentException("Description must be less than 1000 characters long", nameof(desc));

            Value = desc;
        }


        public override string ToString() => Value;
    }
}
