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
    internal abstract class ParsingAction
    {
        private string outputKey;

        protected ParsingAction(string outputKey)
        {
            this.outputKey = outputKey;
        }

        internal abstract void Parse(IIncidentObject inputIncident, IIncidentObject outputObject);

        protected void SetValue(IIncidentObject outputObject, object value)
        {
            outputObject.SetObject(outputKey, value);
        }
    }
}
