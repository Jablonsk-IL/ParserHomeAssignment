using IncidentParserEngine.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.ParseActions
{
    /// <summary>
    /// Sets a default value to output field
    /// </summary>
    class SetDefaultAction : ParsingAction
    {
        string defaultValue;

        public SetDefaultAction(string inputExpression, string outputKey, string defaultValue) : base(inputExpression, outputKey)
        {
            this.defaultValue = defaultValue;
        }

        protected override void RunParser(string input, IIncidentObject outputObject)
        {
            outputObject.SetObject(outputKey, defaultValue);
        }
    }
}
