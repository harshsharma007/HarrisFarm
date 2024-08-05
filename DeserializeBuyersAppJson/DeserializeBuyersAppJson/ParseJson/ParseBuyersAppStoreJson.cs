using DeserializeBuyersAppJson.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DeserializeBuyersAppJson.ParseJson
{
    public class ParseBuyersAppStoreJson : IParseBuyersAppStoreJson
    {
        public BuyersAppStore ParseBuyersAppJson(string BuyersAppStoreJson)
        {
            var buyersAppStoreInfo = JsonConvert.DeserializeObject<BuyersAppStoreInfo>(BuyersAppStoreJson);
            var targetInputParameter = buyersAppStoreInfo?.InputParameters?.FirstOrDefault(ip => ip.Key == "Target");
            var buyersAppStore = new BuyersAppStore();

            if (targetInputParameter != null && targetInputParameter.Value is TargetValue targetValue)
            {
                var attributes = targetValue.Attributes;

                if (attributes != null)
                {
                    foreach (var attribute in attributes)
                    {
                        if (attribute.Key == "mserp_entityid")
                        {
                            buyersAppStore.EntityId = Convert.ToString(attribute.Value);
                        }
                        else if (attribute.Key == "mserp_entityrelationtype")
                        {
                            if (attribute.Value is JObject jObject)
                            {
                                var optionSetValue = jObject.ToObject<OptionSetValue>();
                                if (optionSetValue != null)
                                {
                                    buyersAppStore.EntityRelationType = optionSetValue.Value;
                                }
                            }
                        }
                        else if (attribute.Key == "mserp_entityrelation")
                        {
                            buyersAppStore.EntityRelation = Convert.ToString(attribute.Value);
                        }
                    }
                }
            }

            return buyersAppStore;
        }
    }
}
