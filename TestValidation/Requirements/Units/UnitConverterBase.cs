using System.Collections.Generic;
using static TestValidation.Requirements.Units.UnitConverter;

namespace TestValidation.Requirements.Units
{
    public static class UnitConverterBase
    {
        private static readonly Dictionary<Prefix, double> PrefixFactors = new Dictionary<Prefix, double>
    {
        { Prefix.Yotta, 1e24 },
        { Prefix.Zetta, 1e21 },
        { Prefix.Exa, 1e18 },
        { Prefix.Peta, 1e15 },
        { Prefix.Tera, 1e12 },
        { Prefix.Giga, 1e9 },
        { Prefix.Mega, 1e6 },
        { Prefix.Kilo, 1e3 },
        { Prefix.Hecto, 1e2 },
        { Prefix.Deca, 1e1 },
        { Prefix.None, 1e0 },
        { Prefix.Deci, 1e-1 },
        { Prefix.Centi, 1e-2 },
        { Prefix.Milli, 1e-3 },
        { Prefix.Micro, 1e-6 },
        { Prefix.Nano, 1e-9 },
        { Prefix.Pico, 1e-12 },
        { Prefix.Femto, 1e-15 },
        { Prefix.Atto, 1e-18 },
        { Prefix.Zepto, 1e-21 },
        { Prefix.Yocto, 1e-24 }
    };

        public static double Convert(double value, Unit sourceUnit, Unit targetUnit, Prefix sourcePrefix = Prefix.None, Prefix targetPrefix = Prefix.None)
        {
            double convertedValue = value;

            if (sourcePrefix != Prefix.None)
                convertedValue *= PrefixFactors[sourcePrefix];

            if (targetPrefix != Prefix.None)
                convertedValue /= PrefixFactors[targetPrefix];

            return convertedValue;
        }
    }
}