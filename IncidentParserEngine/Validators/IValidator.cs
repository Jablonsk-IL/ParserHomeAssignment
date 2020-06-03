using IncidentParserEngine.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.Validators
{
    interface IValidator
    {
        bool Validate(IIncidentObject input);
    }
}
