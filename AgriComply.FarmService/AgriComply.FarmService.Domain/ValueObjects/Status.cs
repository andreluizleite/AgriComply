namespace AgriComply.FarmerService.Domain.ValueObjects
{
    public class Status
    {
        public string Value { get; }

        public Status(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Status value cannot be null or empty.", nameof(value));
            }

            Value = value;
        }

        public static Status Onboarded() => new Status("Onboarded");
        public static Status Pending() => new Status("Pending");
        public static Status Verified() => new Status("Verified");
        public static Status Suspended() => new Status("Suspended");

        public override string ToString() => Value;

        public override bool Equals(object? obj)
        {
            if (obj is Status other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}
