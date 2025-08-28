namespace MinimalAPI.Domain.ValueObjects
{
    public record ProductName
    {
        public string Value { get; }

        public ProductName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            Value = name;
        }

        public override string ToString() => Value;
    }
}
