using Nuvo.TestValidation.Calculators.SParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nuvo.TestValidation.Limits.Units
{
    public enum UnitEnum
    {
        None,
        dB,
        Percent,
        Phase_Deg,
        Phase_Rad,
        Hertz,
        Seconds,
        LinearMag,
        Watts,
        dBmV,
        dBmW,
        Real,
        Imaginary,
        Ampere,
        Ohm,
        Farad,
        Henry,
        Volt,
        Celcius,
        Fahrenheit,
        Kelvin,
        Mole,
        Candela,
        Meter,
        SquareMeter,
        CubicMeter,
        gram, 
        Degree,
        Watt,
        Second, 
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
    
    [XmlInclude(typeof(FrequencyUnits))]
    [XmlInclude(typeof(TimeSparamUnits))]
    [XmlInclude(typeof(SParamUnits))]
    public abstract class GenericUnits
    {
        public GenericUnits() {  }

        public UnitEnum Unit { get; set; }
        public PrefixEnum Prefix { get; set; }
        public virtual List<UnitEnum> ValidUnitTypes { get; set; } = Enum.GetValues(typeof(UnitEnum)).Cast<UnitEnum>().ToList();
        public virtual List<PrefixEnum> ValidPrefixTypes { get; set; } = Enum.GetValues(typeof(PrefixEnum)).Cast<PrefixEnum>().ToList();

        public static readonly Dictionary<PrefixEnum, double> PrefixFactors = new Dictionary<PrefixEnum, double>
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

        public static readonly Dictionary<PrefixEnum, string> PrefixStr = new Dictionary<PrefixEnum, string>
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

        // Created in Excel with: =CONCAT("            { UnitEnum.",B4,", ""B4""},") except for updated values like UnitEnum.None
        public static readonly Dictionary<UnitEnum, string> UnitStr = new Dictionary<UnitEnum, string>
        {
            { UnitEnum.None, "None"},
            { UnitEnum.dB, "dB"},
            { UnitEnum.Percent, "Percent"},
            { UnitEnum.Phase_Deg, "Degrees"},
            { UnitEnum.Phase_Rad, "Radians"},
            { UnitEnum.Hertz, "Hertz"},
            { UnitEnum.Seconds, "Seconds"},
            { UnitEnum.LinearMag, "Magnitude"},
            { UnitEnum.Real, "Real"},
            { UnitEnum.Imaginary, "Imaginary"},
            { UnitEnum.Watts, "Watts"},
            { UnitEnum.dBmV, "dBmV"},
            { UnitEnum.dBmW, "dBmW"},
            { UnitEnum.Ampere, "Ampere"},
            { UnitEnum.Ohm, "Ohm"},
            { UnitEnum.Farad, "Farad"},
            { UnitEnum.Henry, "Henry"},
            { UnitEnum.Volt, "Volt"},
            { UnitEnum.Celcius, "Celcius"},
            { UnitEnum.Fahrenheit, "Fahrenheit"},
            { UnitEnum.Kelvin, "Kelvin"},
            { UnitEnum.Mole, "Mole"},
            { UnitEnum.Candela, "Candela"},
            { UnitEnum.Meter, "Meter"},
            { UnitEnum.SquareMeter, "SquareMeter"},
            { UnitEnum.CubicMeter, "CubicMeter"},
            { UnitEnum.gram , "gram "},
            { UnitEnum.Degree, "Degree"},
            { UnitEnum.Watt, "Watt"},

        };

        // Created in Excel with: =CONCAT("            { UnitEnum.",B4,", """,B4,"""},") except for updated values like UnitEnum.None
        public static readonly Dictionary<UnitEnum, string> UnitAbbreviatedStr = new Dictionary<UnitEnum, string>
        {
            { UnitEnum.None, ""},
            { UnitEnum.dB, "dB"},
            { UnitEnum.Percent, "Pct"},
            { UnitEnum.Phase_Deg, "Deg"},
            { UnitEnum.Phase_Rad, "Rad"},
            { UnitEnum.Hertz, "Hz"},
            { UnitEnum.Seconds, "Sec"},
            { UnitEnum.LinearMag, "Mag"},
            { UnitEnum.Watts, "W"},
            { UnitEnum.dBmV, "dBmV"},
            { UnitEnum.dBmW, "dBmW"},
            { UnitEnum.Real, "Real"},
            { UnitEnum.Imaginary, "Imaginary"},
            { UnitEnum.Ampere, "A"},
            { UnitEnum.Ohm, "Ohm"},
            { UnitEnum.Farad, "F"},
            { UnitEnum.Henry, "H"},
            { UnitEnum.Volt, "V"},
            { UnitEnum.Celcius, "C"},
            { UnitEnum.Fahrenheit, "F"},
            { UnitEnum.Kelvin, "K"},
            { UnitEnum.Mole, "Mole"},
            { UnitEnum.Candela, "Candela"},
            { UnitEnum.Meter, "m"},
            { UnitEnum.SquareMeter, "m2"},
            { UnitEnum.CubicMeter, "m3"},
            { UnitEnum.gram , "g"},
            { UnitEnum.Degree, "Deg"},
            { UnitEnum.Watt, "W"},
        };

        /// <summary>Presents the Range in readable format.</summary>
        /// <returns>String representation of the Range</returns>
        public override string ToString()
        {
            return string.Format("{0}{1}",PrefixStr[Prefix], UnitAbbreviatedStr[Unit]);
        }

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
