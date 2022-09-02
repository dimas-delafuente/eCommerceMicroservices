namespace Catalog.Domain.Shared
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left is null || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public bool Equals(ValueObject? other)
        {
            return other is not null && AreEqual(other);
        }

        public override bool Equals(object? obj)
        {
            return obj != null && obj is ValueObject other && AreEqual(other);
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
             .Select(x => (x?.GetHashCode()) ?? 0)
             .Aggregate((x, y) => x ^ y);
        }

        public ValueObject GetCopy()
        {
            return (ValueObject)MemberwiseClone();
        }

        private bool AreEqual(ValueObject obj)
            => GetAtomicValues().SequenceEqual(obj.GetAtomicValues());
    }
}
