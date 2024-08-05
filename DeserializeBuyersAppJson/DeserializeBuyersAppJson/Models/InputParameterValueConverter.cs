using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DeserializeBuyersAppJson.Models
{
    public class InputParameterValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject jObject = JObject.Load(reader);

                if (jObject.TryGetValue("__type", out JToken? typeToken))
                {
                    string type = typeToken.ToString();
                    if (type.Contains("Entity"))
                    {
                        return jObject.ToObject<TargetValue>(serializer);
                    }
                    else if (type.Contains("OptionSetValue"))
                    {
                        return jObject.ToObject<OptionSetValue>(serializer);
                    }
                }

                return jObject.ToObject<object>(serializer); // Default case for other objects
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                return JArray.Load(reader).ToObject<List<object>>(serializer); // Handle array
            }
            else
            {
                return JToken.Load(reader).ToObject<object>(serializer); // Handle simple values
            }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
