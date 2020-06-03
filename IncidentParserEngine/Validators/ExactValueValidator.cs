using IncidentParserEngine.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.Validators
{
    class ExactValueValidator : IValidator
    {
        private string key;
        private string value;

        public ExactValueValidator(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public bool Validate(IIncidentObject input)
        {
            return ((string)input.Get(key)).Equals(value);
        }

    }
}
