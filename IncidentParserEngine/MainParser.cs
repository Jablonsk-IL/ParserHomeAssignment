using IncidentParserEngine.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using IncidentParserEngine.SchemeData;
using IncidentParserEngine.Validators;
using IncidentParserEngine.ParseActions;

namespace IncidentParserEngine
{
    public class MainParser
    {
        Dictionary<string, Scheme> schemeIdToSchemeDictionary;
        Agency[] agencies;

        public MainParser()
        {
            InitializeSchemesDictionary();
            InitializeAgenciesArray();
        }

        public string ParseInput(string input)
        {
            IIncidentObject inputObject = new JsonIncidentObject(input);
            IIncidentObject outputObject = new JsonIncidentObject();
            string schemeId = GetAgencySchemeId(inputObject);
            Scheme scheme = schemeIdToSchemeDictionary[schemeId];

            foreach (IValidator validator in scheme.validators)
            {
                if (!validator.Validate(inputObject))
                {
                    throw new InvalidDataException($"Item failed the {validator.GetType()}");
                }
            }

            foreach (ParsingAction action in scheme.parsers)
            {
                action.Parse(inputObject, outputObject);
            }

            return outputObject.ToString();
        }

        private string GetAgencySchemeId(IIncidentObject input)
        {
            foreach (Agency agency in agencies)
            {
                if (!input.ContainsValue(agency.key))
                {
                    continue;
                }
                if (input.Get(agency.key).Equals(agency.value))
                {
                    return agency.schemeId;
                }
            }

            throw new InvalidDataException("Undefined Agency Encountered");
        }


        // todo : properly attach serialization attributes to parser classes 
        private void InitializeSchemesDictionary()
        {
            var schemePath = ConfigurationManager.AppSettings.Get("SchemePath");
            var schemeJson = File.ReadAllText(schemePath);
            schemeIdToSchemeDictionary = JsonConvert.DeserializeObject<Dictionary<string, Scheme>>(schemeJson);
        }

        private void InitializeAgenciesArray()
        {
            var agenciesPath = ConfigurationManager.AppSettings.Get("AgenciesPath");
            var agenciesJson = File.ReadAllText(agenciesPath);
            agencies = JsonConvert.DeserializeObject<Agency[]>(agenciesJson);
        }
    }
}
