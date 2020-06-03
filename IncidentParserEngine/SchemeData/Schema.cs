using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentParserEngine.Validators;
using IncidentParserEngine.ParseActions;

namespace IncidentParserEngine.SchemeData
{
    [Serializable]
    internal class Scheme
    {
        public IValidator[] validators;
        public ParsingAction[] parsers;
    }
}
