using DeserializeBuyersAppJson.ParseJson;
using System.Text;

namespace DeserializeBuyersAppJson
{
    public class JsonParser(IParseBuyersAppStoreJson parseBuyersAppStoreJson)
    {
        private readonly IParseBuyersAppStoreJson _parseBuyersAppStoreJson = parseBuyersAppStoreJson;

        public void Run()
        {
            var buyersAppStore = _parseBuyersAppStoreJson.ParseBuyersAppJson(Encoding.UTF8.GetString(File.ReadAllBytes("SampleJson.json")));
            Console.WriteLine($"Entity Id = {buyersAppStore.EntityId}, Entity Relation = {buyersAppStore.EntityRelation} & Entity Relation Type = {buyersAppStore.EntityRelationType}");
        }
    }
}
