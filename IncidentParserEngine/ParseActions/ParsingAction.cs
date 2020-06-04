using IncidentParserEngine.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.ParseActions
{
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
