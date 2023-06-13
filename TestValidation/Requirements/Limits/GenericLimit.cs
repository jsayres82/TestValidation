using System;
using System.Xml.Serialization;
using static TestValidation.Requirements.Units.UnitConverter;

namespace TestValidation.Requirements.Limits
{
    [Serializable]
    public abstract class GenericLimit<T>
    {
        [XmlElement("Value")]
        public T Value { get; set; }

        [XmlElement("Unit")]
        public Unit Unit { get; set; }

        [XmlElement("Prefix")]
        public Prefix Prefix { get; set; }

        protected GenericLimit()
        {
        }

        protected GenericLimit(T value, Unit unit, Prefix prefix)
        {
            Value = value;
            Unit = unit;
            Prefix = prefix;
        }

        public abstract bool Validate(T measurement);

        public virtual string GetFormattedValue()
        {
            return $"{Value} {Prefix}{Unit}";
        }
    }

    [Serializable]
    public class GreaterThanLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        public GreaterThanLimit()
        {
        }

        public GreaterThanLimit(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) > 0;
        }
    }

    [Serializable]
    public class GreaterThanOrEqualLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        public GreaterThanOrEqualLimit()
        {
        }

        public GreaterThanOrEqualLimit(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) >= 0;
        }
    }

    [Serializable]
    public class LessThanLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        public LessThanLimit()
        {
        }

        public LessThanLimit(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) < 0;
        }
    }

    [Serializable]
    public class LessThanOrEqualLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        public LessThanOrEqualLimit()
        {
        }

        public LessThanOrEqualLimit(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) <= 0;
        }
    }

    [Serializable]
    public class EqualLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        public EqualLimit()
        {
        }

        public EqualLimit(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) == 0;
        }
    }

    [Serializable]
    public class NotEqualLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        public NotEqualLimit()
        {
        }

        public NotEqualLimit(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) != 0;
        }
    }

    [Serializable]
    public class BoundedLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        public BoundedLimit()
        {
        }

        public BoundedLimit(T lowerBound, T upperBound, Unit unit, Prefix prefix)
            : base(default, unit, prefix)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        [XmlElement("LowerBound")]
        public T LowerBound { get; set; }

        [XmlElement("UpperBound")]
        public T UpperBound { get; set; }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(LowerBound) >= 0 && measurement.CompareTo(UpperBound) <= 0;
        }
    }

    [Serializable]
    public class ToleranceLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        public ToleranceLimit()
        {
        }

        public ToleranceLimit(T value, T tolerance, Unit unit, Prefix prefix)
            : base(value, unit, prefix)
        {
            Tolerance = tolerance;
        }

        [XmlElement("Tolerance")]
        public T Tolerance { get; set; }

        public override bool Validate(T measurement)
        {
            T lowerBound = Subtract(measurement, Tolerance);
            T upperBound = Add(measurement, Tolerance);
            return measurement.CompareTo(lowerBound) >= 0 && measurement.CompareTo(upperBound) <= 0;
        }

        private static T Add(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da + db;
        }

        private static T Subtract(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da - db;
        }
    }

    [Serializable]
    public class PercentageLimit<T> : GenericLimit<T> where T : IComparable<T>, IConvertible
    {
        public PercentageLimit()
        {
        }

        public PercentageLimit(T value, double percentage, Unit unit, Prefix prefix)
            : base(value, unit, prefix)
        {
            Percentage = percentage;
        }

        [XmlElement("Percentage")]
        public double Percentage { get; set; }

        public override bool Validate(T measurement)
        {
            double value = System.Convert.ToDouble(Value);
            double minValue = value - (value * (Percentage / 100));
            double maxValue = value + (value * (Percentage / 100));

            double measuredValue = System.Convert.ToDouble(measurement);

            return measuredValue >= minValue && measuredValue <= maxValue;
        }
    }
    [Serializable]
    public class RampLimit<T> : GenericLimit<T> where T : IComparable<T>
    {
        [XmlElement("RampRate")]
        public T RampRate { get; set; }

        public RampLimit()
        {
        }

        public RampLimit(T value, T rampRate, Unit unit, Prefix prefix)
            : base(value, unit, prefix)
        {
            RampRate = rampRate;
        }

        public override bool Validate(T measurement)
        {
            T lowerBound = Subtract(Value, Multiply(RampRate, measurement));
            T upperBound = Add(Value, Multiply(RampRate, measurement));
            return measurement.CompareTo(lowerBound) >= 0 && measurement.CompareTo(upperBound) <= 0;
        }

        private static T Multiply(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da * db;
        }

        private static T Add(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da + db;
        }

        private static T Subtract(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da - db;
        }
    }
    public class DomainLimit<T, U> : GenericLimit<T> where T : IComparable<T>
    {
        public U StartValue { get; set; }
        public U EndValue { get; set; }
        public Prefix Prefix { get; set; }

        // Parameterless constructor required for serialization
        public DomainLimit()
        {
        }

        public DomainLimit(T value, U startValue, U endValue, Prefix prefix, Unit unit)
            : base(value, unit, prefix)
        {
            StartValue = startValue;
            EndValue = endValue;
            Prefix = prefix;
        }

        public override bool Validate(T measurement)
        {
            // Check if measurement falls within the specified domain
            if (measurement.CompareTo(Value) < 0 || measurement.CompareTo(Value) > 0)
                return false;

            return true;
        }
    }
}
