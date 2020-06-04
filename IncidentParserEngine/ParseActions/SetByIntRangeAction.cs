using IncidentParserEngine.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.ParseActions
{
    /// <summary>
    /// Action class returning whether int input is in range defined by schema
    /// </summary>
    class SetByIntRangeAction : ExpressionBasedParsingAction
    {
        int? min;
        int? max;
        bool isMinExclusive;
        bool isMaxExclusive;
        bool value;

        public SetByIntRangeAction(string inputExpression, string targetKey, int? min, int? max, bool isMinExclusive, bool isMaxExclusive, bool value)
            : base (inputExpression, targetKey)
        {
            this.min = min;
            this.max = max;
            this.isMinExclusive = isMinExclusive;
            this.isMaxExclusive = isMaxExclusive;
            this.value = value;
        }

        protected override void RunParser(IIncidentObject outputObject, string input)
        {
            int inputValue = FormattingUtilities.ParseinputExpressionToNumericValue<int>(input);
            if (IsEqualValidBoundry(inputValue))
            {
                SetValue(outputObject);
            }

            if (min != null && inputValue < min)
            {
                return;
            }

            if (max != null && inputValue > max)
            {
                return;
            }

            SetValue(outputObject);
        }

        // Checking if the number is and should be exactly one of the boundries
        private bool IsEqualValidBoundry(int inputValue)
        {
            if (!isMaxExclusive && max != null && inputValue == max)
            {
                return true;
            }

            if (!isMinExclusive && min != null && inputValue == min)
            {
                return true;
            }

            return false;
        }

        private void SetValue(IIncidentObject outputObject)
        {
            SetValue(outputObject, value);
        }
    }
}
