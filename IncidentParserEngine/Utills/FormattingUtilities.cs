using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IncidentParserEngine.Utills
{
    public static class FormattingUtilities
    {
        // regex for all values contained in curly brackets
        static readonly Regex keysRegex = new Regex("{(.*?)}");

        /// <summary>
        /// Get a math evaluation according to given expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputExpression">Math expression to evaluate</param>
        /// <returns></returns>
        public static T ParseinputExpressionToNumericValue<T>(string inputExpression)
        {
            DataTable dt = new DataTable();
            return (T)dt.Compute(inputExpression, string.Empty);
        }


        /// <summary>
        /// Replaces keys with the corresponding value from incident - ex "{key1} + {key2} /2 " -> "24 + 13 / 2"
        /// </summary>
        /// <param name="input">Input incident object containing values for expression formatting</param>
        /// <param name="inputExpression">Expression that will be formatted into value string</param>
        /// <returns></returns>
        public static string ReplaceKeysInStringWithValues(IIncidentObject input, string inputExpression)
        {
            MatchCollection matches = keysRegex.Matches(inputExpression);

            foreach (Match match in matches)
            {
                inputExpression = inputExpression.Replace(match.Value, input.Get(match.Value).ToString());
            }

            return inputExpression;
        }
    }
}
