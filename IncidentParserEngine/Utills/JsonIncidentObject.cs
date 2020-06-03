using IncidentParserEngine.Utills;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentParserEngine.Utills
{
    class JsonIncidentObject : IIncidentObject
    {
        private JObject rootObject;
        public JsonIncidentObject()
        {
            rootObject = new JObject();
        }
        public JsonIncidentObject(string input)
        {
            rootObject = JObject.Parse(input);
        }

        public bool ContainsValue(string key)
        {
            return rootObject.ContainsKey(key);
        }

        public object Get(string key)
        {
            return rootObject.GetValue(key).Value<string>();
        }

        public void SetObject(string key, object value)
        {
            rootObject.Add(key, JToken.FromObject(value));
        }

        public override string ToString()
        {
            return rootObject.ToString();
        }
    }
}
