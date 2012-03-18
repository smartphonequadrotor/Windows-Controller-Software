using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace QoD_DataCentre.Domain.JSON
{
    public class JsonManager
    {
        public JsonManager()
        {       
        }

        public JsonObjects.Envelope DeserializeEnvelope(string json)
        {
            return JsonConvert.DeserializeObject<JsonObjects.Envelope>(json);
        }
    }
}
