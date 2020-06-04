using IncidentParserEngine.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.ParseActions
{

    /// <summary>
    /// Base action class for all parsers using a simple single value input expression
    /// </summary>
    abstract class ExpressionBasedParsingAction : ParsingAction
    {
        private string inputExpression;
        
        protected ExpressionBasedParsingAction(string inputExpression, string outputKey) : base (outputKey)
        {
            this.inputExpression = inputExpression;
        }

        internal override void Parse(IIncidentObject inputIncident, IIncidentObject outputObject)
        {
            string inputValue = FormattingUtilities.ReplaceKeysInStringWithValues(inputIncident, inputExpression);
            RunParser(outputObject, inputValue);
        }

        protected abstract void RunParser(IIncidentObject outputObject, string input);
    }
}
