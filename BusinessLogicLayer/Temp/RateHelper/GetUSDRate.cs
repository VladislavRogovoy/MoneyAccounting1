using BusinessLogicLayer.Temp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace BusinessLogicLayer.Temp.RateHelper
{
    public class GetUSDRate : GetRateStrategy
    {
        public override float GetRate()
        {
            var client = new HttpClient();
            var USDResponse = client.GetAsync("https://www.nbrb.by/api/exrates/rates/USD?parammode=2");
            if (USDResponse.Result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("bad response of www.nbrb.by/api/exrates/rates/USD?parammode=2");
            }
            var USDResponseString = USDResponse.Result.Content.ReadAsStringAsync();
            var USDRate = JsonConvert.DeserializeObject<CurrencyResponse>(USDResponseString.Result);
            if (USDRate.CurScale > 1)
            {
                USDRate.OfficialRate = USDRate.OfficialRate / USDRate.CurScale;
            }
            return USDRate.OfficialRate;
        }
    }
}
