using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CTM.Serialisation
{
    public static class JsonNet
    {
        public static class CamelCase
        {
            public static string Serialise(object o, JsonSerializerSettings settings = null)
            {
                if (settings == null)
                {
                    return JsonConvert.SerializeObject(o, Settings);    
                }
                
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                return JsonConvert.SerializeObject(o, settings);
            }

            public static T Deserialise<T>(string serialisedString, JsonSerializerSettings settings = null)
            {
                if (settings == null)
                {
                    return JsonConvert.DeserializeObject<T>(serialisedString, Settings);
                }

                settings.ContractResolver = new CamelCasePropertyNamesContractResolver(); 
                
                return JsonConvert.DeserializeObject<T>(serialisedString, settings);
            }

            private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}
