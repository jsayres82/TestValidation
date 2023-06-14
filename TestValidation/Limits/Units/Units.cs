using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestValidation.Requirements.Units
{
    public abstract class Unit
    {
        public string Symbol { get; protected set; }

        protected Unit(string symbol)
        {
            Symbol = symbol;
        }

        public abstract double ConvertTo(double value, Unit targetUnit);
    }

    public class BaseUnit : Unit
    {
        public BaseUnit(string symbol) : base(symbol)
        {
        }

        public override double ConvertTo(double value, Unit targetUnit)
        {
            if (targetUnit is BaseUnit targetBaseUnit)
            {
                return value; // Conversion within the same base unit, no change needed
            }

            throw new ArgumentException("Invalid conversion.");
        }
    }

    public class DerivedUnit : Unit
    {
        public Dictionary<Unit, int> Units { get; }

        public DerivedUnit(string symbol, Dictionary<Unit, int> units) : base(symbol)
        {
            Units = units;
        }

        public override double ConvertTo(double value, Unit targetUnit)
        {
            if (targetUnit is DerivedUnit targetDerivedUnit && Units.Count == targetDerivedUnit.Units.Count)
            {
                double result = value;
                foreach (var kvp in Units)
                {
                    if (targetDerivedUnit.Units.TryGetValue(kvp.Key, out int targetExponent))
                    {
                        double conversionFactor = Math.Pow(kvp.Key.ConvertTo(1, targetDerivedUnit), kvp.Value);
                        result *= Math.Pow(conversionFactor, targetExponent);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid conversion.");
                    }
                }
                return result;
            }

            throw new ArgumentException("Invalid conversion.");
        }
    }

    public static class Units
    {
        // Base SI Units
        public static readonly BaseUnit Meter = new BaseUnit("m");
        public static readonly BaseUnit Kilogram = new BaseUnit("kg");
        public static readonly BaseUnit Second = new BaseUnit("s");
        public static readonly BaseUnit Ampere = new BaseUnit("A");
        public static readonly BaseUnit Kelvin = new BaseUnit("K");
        public static readonly BaseUnit Mole = new BaseUnit("mol");
        public static readonly BaseUnit Candela = new BaseUnit("cd");

        // Derived Units
        public static readonly DerivedUnit SquareMeter = new DerivedUnit("m²", new Dictionary<Unit, int> { { Meter, 2 } });
        public static readonly DerivedUnit CubicMeter = new DerivedUnit("m³", new Dictionary<Unit, int> { { Meter, 3 } });
        public static readonly DerivedUnit Hertz = new DerivedUnit("Hz", new Dictionary<Unit, int> { { Second, -1 } });
        public static readonly DerivedUnit Ohm = new DerivedUnit("Ω", new Dictionary<Unit, int> { { Kilogram, 1 }, { Meter, 2 }, { Second, -3 }, { Ampere, -2 } });
        public static readonly DerivedUnit Farad = new DerivedUnit("F", new Dictionary<Unit, int> { { Kilogram, -1 }, { Meter, -2 }, { Second, 4 }, { Ampere, 2 } });
        public static readonly DerivedUnit Henry = new DerivedUnit("H", new Dictionary<Unit, int> { { Kilogram, 1 }, { Meter, 2 }, { Second, -2 }, { Ampere, -2 } });
        public static readonly DerivedUnit Volt = new DerivedUnit("V", new Dictionary<Unit, int> { { Kilogram, 1 }, { Meter, 2 }, { Second, -3 }, { Ampere, -1 } });
        public static readonly DerivedUnit Watt = new DerivedUnit("W", new Dictionary<Unit, int> { { Kilogram, 1 }, { Meter, 2 }, { Second, -3 } });
        public static readonly DerivedUnit Decibel = new DerivedUnit("dB", new Dictionary<Unit, int> { { Units.Watt, 1 } });

        // RF-specific Units
        public static readonly DerivedUnit DecibelMilliwatt = new DerivedUnit("dBm", new Dictionary<Unit, int> { { Decibel, 1 }, { MilliWatt, 1 } });
        public static readonly DerivedUnit DecibelMicroVolt = new DerivedUnit("dBµV", new Dictionary<Unit, int> { { Decibel, 1 }, { MicroVolt, 1 } });

        // Common Units
        public static readonly BaseUnit Percent = new BaseUnit("%");
        public static readonly BaseUnit MilliWatt = new BaseUnit("mW");
        public static readonly BaseUnit MicroVolt = new BaseUnit("µV");

        // Conversion factor constants for prefixes
        private const double KiloFactor = 1E3;
        private const double MilliFactor = 1E-3;
        private const double MicroFactor = 1E-6;

        static Units()
        {
            // Update conversion factors for prefixed units
            Kilogram.ConvertTo = (value, targetUnit) => value * GetPrefixFactor(targetUnit.Symbol) / GetPrefixFactor(Kilogram.Symbol);
            Meter.ConvertTo = (value, targetUnit) => value * GetPrefixFactor(targetUnit.Symbol) / GetPrefixFactor(Meter.Symbol);
            Second.ConvertTo = (value, targetUnit) => value * GetPrefixFactor(targetUnit.Symbol) / GetPrefixFactor(Second.Symbol);
            Ampere.ConvertTo = (value, targetUnit) => value * GetPrefixFactor(targetUnit.Symbol) / GetPrefixFactor(Ampere.Symbol);
            Kelvin.ConvertTo = (value, targetUnit) => value;
            Mole.ConvertTo = (value, targetUnit) => value;
            Candela.ConvertTo = (value, targetUnit) => value;
        }

        // Helper method to get prefix factor based on symbol
        private static double GetPrefixFactor(string symbol)
        {
            switch (symbol)
            {
                case "":
                    return 1.0;
                case "k":
                    return KiloFactor;
                case "m":
                    return MilliFactor;
                case "µ":
                    return MicroFactor;
                default:
                    throw new ArgumentException("Invalid prefix symbol.");
            }
        }
    }
}
