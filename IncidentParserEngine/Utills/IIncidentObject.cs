using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.Utills
{
    public interface IIncidentObject
    {
        object Get(string key);
        bool ContainsValue(string key);
        void SetObject(string key, object value);
    }
}
