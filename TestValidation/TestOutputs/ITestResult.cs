using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.TestResults
{
    public interface ITestResult
    {
        string RequirementName { get; set; }
        bool Passed { get; set; }
        double ValueAtMinimumMargin { get; set; }
        double MinimumMargin { get; set; }
    }
}
