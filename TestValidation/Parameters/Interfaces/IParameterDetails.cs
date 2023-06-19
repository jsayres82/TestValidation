using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Parameters.Interfaces
{
    public interface IParameterDetails
    {
        public double MinimumMargin { get; set; }
        //public double[] ParameterValues { get; set; }
        public double[] GetParameterLimits();

    }
}
