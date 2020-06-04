using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentParserEngine.Utills;

namespace IncidentParserEngine.ParseActions
{
    /// <summary>
    /// Simple parser passing field from input event into output event keeping the original value
    /// </summary>
    class PassFieldAction : ParsingAction
    {
        public PassFieldAction(string inputExpression, string outputKey) : base(inputExpression, outputKey)
        {
        }

        protected override void RunParser(string input, IIncidentObject outputObject)
        {
            outputObject.SetObject(outputKey, input);
        }
    }
}
