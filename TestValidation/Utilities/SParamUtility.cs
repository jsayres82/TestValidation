using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Utilities
{
    internal class SParamUtility
    {
        public static List<string> GenerateSparamStrings(string extension)
        {
            var portCount = 0;
            var sParamList = new List<string>();
            if (extension.Length > 4)
            {
                portCount = Convert.ToInt32(extension.Substring(2, 2));
            }
            else
            {
                var x = extension.Substring(2, 1);
                portCount = Convert.ToInt32(extension.Substring(2, 1));
            }
            for (int i = 1; i <= portCount; i++)
            {
                for (int j = 1; j <= portCount; j++)
                {
                    if (j < 10 & i < 10)
                    {
                        sParamList.Add($@"S{i}{j}");
                    }
                    else
                    {
                        sParamList.Add($@"S{i}_{j}");
                    }
                }
            }
            return sParamList;
        }
    }
}
