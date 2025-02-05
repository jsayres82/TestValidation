using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Nuvo.TestValidation.Limits.Validators;
using Newtonsoft.Json;

namespace Nuvo.TestValidation.Limits
{
    /// <summary>
    /// Range and Domain could be handled with same class but this makes doing things like evaluating gain over frequency and gain over az/el cleaner
    /// </summary>
    public abstract class GenericLimit
    {
        [XmlElement("GreaterThanOrEqualValidator", typeof(GreaterThanOrEqualValidator<double>))]
        [XmlElement("GreaterThanValidator", typeof(GreaterThanValidator<double>))]
        [XmlElement("LessThanOrEqualValidator", typeof(LessThanOrEqualValidator<double>))]
        [XmlElement("LessThanValidator", typeof(LessThanValidator<double>))]
        [XmlElement("NotEqualValidator", typeof(NotEqualValidator<double>))]
        [XmlElement("EqualValidator", typeof(EqualValidator<double>))]
        [XmlElement("ToleranceValidator", typeof(ToleranceValidator<double>))]
        [XmlElement("PercentageValidator", typeof(PercentageValidator<double>))]
        [XmlElement("RampValidator", typeof(RampValidator<double>))]
        [XmlElement("BoundedValidator", typeof(BoundedValidator<double>))]
        public abstract GenericValidator<double> Validator { get; set; }
        [XmlIgnore]
        public bool IsSLopedLimit = false;
        //[JsonProperty("StartFrequency")]
        [XmlElement("StartFrequency")]
        public virtual double Start { get; set; }

        //[JsonProperty("StartFrequency")]
        [XmlElement("EndFrequency")]
        public virtual double End { get; set; }

        public abstract double CalculateMargin(double domainValue, double rangeValue);

        public virtual bool ValidateMeasurement(double freq, double measurement)
        {
            return Validator.Validate(measurement);  
        }

        public virtual bool ValidateMeasurement(double measurement)
        {
            return Validator.Validate(measurement);
        }


        public void SetValidator(object validator)
        {
            if (validator is GreaterThanOrEqualValidator<double>)
            {
                Validator = (GreaterThanOrEqualValidator<double>)validator;
            }
            else if (validator is GreaterThanValidator<double>)
            {
                Validator = (GreaterThanValidator<double>)validator;
            }
            else if (validator is LessThanOrEqualValidator<double>)
            {
                Validator = (LessThanOrEqualValidator<double>)validator;
            }
            else if (validator is LessThanValidator<double>)
            {
                Validator = (LessThanValidator<double>)validator;
            }
            else if (validator is NotEqualValidator<double>)
            {
                Validator = (NotEqualValidator<double>)validator;
            }
            else if (validator is EqualValidator<double>)
            {
                Validator = (EqualValidator<double>)validator;
            }
            else if (validator is ToleranceValidator<double>)
            {
                Validator = (ToleranceValidator<double>)validator;
            }
            else if (validator is PercentageValidator<double>)
            {
                Validator = (PercentageValidator<double>)validator;
            }
            else if (validator is RampValidator<double>)
            {
                Validator = (RampValidator<double>)validator;
            }
            else if (validator is BoundedValidator<double>)
            {
                Validator = (BoundedValidator<double>)validator;
            }
        }

        public static Dictionary<string, Type> GetLimitTypes()
        {
            return Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => t.IsClass && !t.IsAbstract && typeof(GenericLimit).IsAssignableFrom(t)) // concrete class, inheriting from GenericLimit
                        .ToDictionary(t => t.Name, t => t);
        }
    }

}
