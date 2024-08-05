using Newtonsoft.Json;

namespace DeserializeBuyersAppJson.Models
{
    public class BuyersAppStoreInfo
    {
        public List<InputParameter>? InputParameters { get; set; }
    }

    public class InputParameter
    {
        public string? Key { get; set; }

        [JsonConverter(typeof(InputParameterValueConverter))]
        public object? Value { get; set; }
    }

    public class TargetValue
    {
        public List<Attribute>? Attributes { get; set; }
    }

    public class Attribute
    {
        public string? Key { get; set; }
        public object? Value { get; set; }
    }

    public class OptionSetValue
    {
        public int Value { get; set; }
    }
}
