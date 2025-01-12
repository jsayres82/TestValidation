using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Limits.Units
{
    public static class UnitConverter
    {
        public enum UnitEnum
        {
            None,
            dB,
            dBmW,
            dBmV,
            Hertz,
            Meter,
            Kilogram,
            Second,
            Ampere,
            Kelvin,
            Mole,
            Candela,
            SquareMeter,
            CubicMeter,
            Ohm,
            Farad,
            Henry,
            Volt,
            Watt,
            Percent,
            MilliWatt,
            MicroVolt,
            Degree,
            Phase
        };
        

        public enum PrefixEnum
        {
            Yotta,
            Zetta,
            Exa,
            Peta,
            Tera,
            Giga,
            Mega,
            Kilo,
            Hecto,
            Deca,
            None,
            Deci,
            Centi,
            Milli,
            Micro,
            Nano,
            Pico,
            Femto,
            Atto,
            Zepto,
            Yocto
        }

        private static readonly Dictionary<PrefixEnum, double> PrefixFactors = new Dictionary<PrefixEnum, double>
        {
            { PrefixEnum.Yotta, 1e24 },
            { PrefixEnum.Zetta, 1e21 },
            { PrefixEnum.Exa, 1e18 },
            { PrefixEnum.Peta, 1e15 },
            { PrefixEnum.Tera, 1e12 },
            { PrefixEnum.Giga, 1e9 },
            { PrefixEnum.Mega, 1e6 },
            { PrefixEnum.Kilo, 1e3 },
            { PrefixEnum.Hecto, 1e2 },
            { PrefixEnum.Deca, 1e1 },
            {PrefixEnum.None, 1e0 },
            { PrefixEnum.Deci, 1e-1 },
            { PrefixEnum.Centi, 1e-2 },
            { PrefixEnum.Milli, 1e-3 },
            { PrefixEnum.Micro, 1e-6 },
            { PrefixEnum.Nano, 1e-9 },
            { PrefixEnum.Pico, 1e-12 },
            { PrefixEnum.Femto, 1e-15 },
            { PrefixEnum.Atto, 1e-18 },
            { PrefixEnum.Zepto, 1e-21 },
            { PrefixEnum.Yocto, 1e-24 }
        };

        private static readonly Dictionary<PrefixEnum, string> PrefixString = new Dictionary<PrefixEnum, string>
    {
        { PrefixEnum.Yotta, "Y" },
        { PrefixEnum.Zetta, "Z" },
        { PrefixEnum.Exa, "E" },
        { PrefixEnum.Peta, "P" },
        { PrefixEnum.Tera, "T" },
        { PrefixEnum.Giga, "G" },
        { PrefixEnum.Mega, "M" },
        { PrefixEnum.Kilo, "k" },
        { PrefixEnum.Hecto, "" },
        { PrefixEnum.Deca, "" },
        { PrefixEnum.None, "" },
        { PrefixEnum.Deci, "" },
        { PrefixEnum.Centi, "" },
        { PrefixEnum.Milli, "m" },
        { PrefixEnum.Micro, "u" },
        { PrefixEnum.Nano, "n" },
        { PrefixEnum.Pico, "p" },
        { PrefixEnum.Femto, "f" },
        { PrefixEnum.Atto, "a" },
        { PrefixEnum.Zepto, "z" },
        { PrefixEnum.Yocto, "y" }
    };

        public static double Convert(double value, UnitEnum sourceUnit, UnitEnum targetUnit, PrefixEnum sourcePrefix = PrefixEnum.None, PrefixEnum targetPrefix = PrefixEnum.None)
        {
            double convertedValue = value;

            if (sourcePrefix != PrefixEnum.None)
                convertedValue *= PrefixFactors[sourcePrefix];

            if (targetPrefix != PrefixEnum.None)
                convertedValue /= PrefixFactors[targetPrefix];

            return convertedValue;
        }

    }
}
