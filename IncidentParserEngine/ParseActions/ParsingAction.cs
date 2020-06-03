using IncidentParserEngine.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.ParseActions
{

    /// <summary>
    /// base parsing action class, deriving classes represent a parsing action, and are responsible to 
    /// update the corresponding field in the output object
    /// </summary>
    abstract class ParsingAction
    {
        private string inputExpression;
        protected string outputKey;

        protected ParsingAction(string inputExpression, string outputKey)
        {
            this.inputExpression = inputExpression;
            this.outputKey = outputKey;
        }

        public virtual void Parse(IIncidentObject inputIncident, IIncidentObject outputObject)
        {
            string inputValue = FormattingUtilities.ReplaceKeysInStringWithValues(inputIncident, inputExpression);
            RunParser(inputValue, outputObject);
        }
        protected abstract void RunParser(string input, IIncidentObject outputObject);
    }
}
