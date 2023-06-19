using System;
using System.Xml.Serialization;
using static Nuvo.TestValidation.Limits.Units.UnitConverter;

namespace Nuvo.TestValidation.Limits.Validators
{
    [Serializable]
    public abstract class GenericValidator<T>
    {
        [XmlElement("Value")]
        public T Value { get; set; }

        [XmlElement("Unit")]
        public Unit Unit { get; set; }

        [XmlElement("Prefix")]
        public Prefix Prefix { get; set; }

        protected GenericValidator()
        {
        }

        protected GenericValidator(T value, Unit unit, Prefix prefix)
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

        public virtual T CalculateMargin(T measurement)
        {
            dynamic measurementDynamic = measurement;
            dynamic value = Value;

            // EqualValidator checks if a measurement equals a specific value, we calculate the absolute difference with the base value
            return Math.Abs(value - measurementDynamic);
        }
    }

    [Serializable]
    public class GreaterThanValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        public GreaterThanValidator()
        {
        }

        public GreaterThanValidator(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) > 0;
        }
        public override T CalculateMargin(T measurement)
        {
            dynamic value = Value;
            dynamic measurementDynamic = measurement;

            return measurementDynamic - value; // measurement minus limit for GreaterThan
        }
    }

    [Serializable]
    public class GreaterThanOrEqualValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        public GreaterThanOrEqualValidator()
        {
        }

        public GreaterThanOrEqualValidator(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) >= 0;
        }
        public override T CalculateMargin(T measurement)
        {
            dynamic value = Value;
            dynamic measurementDynamic = measurement;

            return measurementDynamic - value; // measurement minus limit for GreaterThan
        }
    }

    [Serializable]
    public class LessThanValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        public LessThanValidator()
        {
        }

        public LessThanValidator(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) < 0;
        }
        public override T CalculateMargin(T measurement)
        {
            dynamic value = Value;
            dynamic measurementDynamic = measurement;

            return value - measurementDynamic; // limit minus measurement for LessThan
        }
    }

    [Serializable]
    public class LessThanOrEqualValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        public LessThanOrEqualValidator()
        {
        }

        public LessThanOrEqualValidator(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) <= 0;
        }
        public override T CalculateMargin(T measurement)
        {
            dynamic value = Value;
            dynamic measurementDynamic = measurement;

            return value - measurementDynamic; // limit minus measurement for LessThan
        }
    }

    [Serializable]
    public class EqualValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        public EqualValidator()
        {
        }

        public EqualValidator(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) == 0;
        }
    }

    [Serializable]
    public class NotEqualValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        public NotEqualValidator()
        {
        }

        public NotEqualValidator(T value, Unit unit, Prefix prefix) : base(value, unit, prefix)
        {
        }

        public override bool Validate(T measurement)
        {
            return measurement.CompareTo(Value) != 0;
        }
    }

    [Serializable]
    public class BoundedValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        public BoundedValidator()
        {
        }

        public BoundedValidator(T lowerBound, T upperBound, Unit unit, Prefix prefix)
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

        public override T CalculateMargin(T measurement)
        {
            dynamic measurementDynamic = measurement;
            dynamic lowerBound = LowerBound;
            dynamic upperBound = UpperBound;

            if (measurement.CompareTo(LowerBound) < 0) // If measurement is less than LowerBound
            {
                return lowerBound - measurementDynamic; // Return the difference with LowerBound
            }
            else if (measurement.CompareTo(UpperBound) > 0) // If measurement is greater than UpperBound
            {
                return measurementDynamic - upperBound; // Return the difference with UpperBound
            }
            else
            {
                return default; // Measurement is within bounds, so margin is zero
            }
        }
    }

    [Serializable]
    public class ToleranceValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        public ToleranceValidator()
        {
        }

        public ToleranceValidator(T value, T tolerance, Unit unit, Prefix prefix)
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

        public override T CalculateMargin(T measurement)
        {
            dynamic value = Value;
            dynamic measurementDynamic = measurement;

            return Math.Abs(value - measurementDynamic); // absolute difference for tolerance
        }

    }

    [Serializable]
    public class PercentageValidator<T> : GenericValidator<T> where T : IComparable<T>, IConvertible
    {
        public PercentageValidator()
        {
        }

        public PercentageValidator(T value, double percentage, Unit unit, Prefix prefix)
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

        public override T CalculateMargin(T measurement)
        {
            double value = System.Convert.ToDouble(Value);
            double measuredValue = System.Convert.ToDouble(measurement);

            double margin = Math.Abs(value - measuredValue) / value; // percentage margin

            return (T)System.Convert.ChangeType(margin, typeof(T));
        }

    }
    [Serializable]
    public class RampValidator<T> : GenericValidator<T> where T : IComparable<T>
    {
        [XmlElement("RampRate")]
        public T RampRate { get; set; }

        public RampValidator()
        {
        }

        public RampValidator(T value, T rampRate, Unit unit, Prefix prefix)
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
    public class DomainValidator<T, U> : GenericValidator<T> where T : IComparable<T>
    {
        public U StartValue { get; set; }
        public U EndValue { get; set; }
        public Prefix Prefix { get; set; }

        // Parameterless constructor required for serialization
        public DomainValidator()
        {
        }

        public DomainValidator(T value, U startValue, U endValue, Prefix prefix, Unit unit)
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
