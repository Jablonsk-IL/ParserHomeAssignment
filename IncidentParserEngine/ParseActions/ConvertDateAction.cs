using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentParserEngine.Utills;

namespace IncidentParserEngine.ParseActions
{
    class ConvertDateAction : ExpressionBasedParsingAction
    {
        string outputFormat;

        public ConvertDateAction(string inputExpression, string outputKey, string outputFormat) : base(inputExpression, outputKey)
        {
            this.outputFormat = outputFormat;
        }

        protected override void RunParser(IIncidentObject outputObject, string input)
        {
            DateTime inputDate = DateTime.Parse(input);
            TimeSpan timeSpan = inputDate - DateTime.MinValue;

            switch(outputFormat)
            {
                case "milliseconds":
                    SetValue(outputObject, timeSpan.Milliseconds);
                    break;

                case "days":
                default:
                    SetValue(outputObject, timeSpan.Days);
                    break;
            }
        }
    }
}
