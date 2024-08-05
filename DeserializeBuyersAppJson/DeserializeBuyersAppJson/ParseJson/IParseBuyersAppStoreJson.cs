using DeserializeBuyersAppJson.Models;

namespace DeserializeBuyersAppJson.ParseJson
{
    public interface IParseBuyersAppStoreJson
    {
        BuyersAppStore ParseBuyersAppJson(string BuyersAppStoreJson);
    }
}