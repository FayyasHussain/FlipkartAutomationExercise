using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flipkart.Automation.Core
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string textToChange)
        {
            if (textToChange == null)
            {
                return null;
            }

            System.Text.StringBuilder resultBuilder = new System.Text.StringBuilder();
            foreach (char c in textToChange)
            {
                if (!c.Equals('"') && !c.Equals('\\'))
                {
                    if (string.IsNullOrEmpty(resultBuilder.ToString().Trim()))
                    {
                        resultBuilder.Append(char.ToUpper(c));
                    }
                    else
                    {
                        resultBuilder.Append(c);
                    }
                }
            }

            textToChange = resultBuilder.ToString();
            return textToChange.Replace(" ", string.Empty);
        }
    }
}
