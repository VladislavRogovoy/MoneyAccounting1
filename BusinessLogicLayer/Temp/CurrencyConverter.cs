using BusinessLogicLayer.Temp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace BusinessLogicLayer.Temp
{
    public class CurrencyConverter
    {
        private static float BYNUSDRate { get; set; }
        private static float BYNEURRate { get; set; }
        private static float BYNRUBRate { get; set; }
        private CurrencyConverter() { }

        private static CurrencyConverter _converter;

        public static CurrencyConverter GetConverter()
        {
            if (_converter == null)
            {
                _converter = new CurrencyConverter();
            }

            return _converter;
        }

        private float GetRate(string toCurrency)
        {
            if (toCurrency == "USD" && BYNUSDRate != 0)
            {
                return BYNUSDRate;
            }else if (toCurrency == "EUR" && BYNEURRate != 0)
            {
                return BYNEURRate;
            }else if (toCurrency == "RUB" && BYNRUBRate != 0)
            {
                return BYNRUBRate;
            }
            
            var client = new HttpClient();
            var response = client.GetAsync(String.Format("https://www.nbrb.by/api/exrates/rates/{0}?parammode=2", toCurrency.ToUpper()));
            if (response.Result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("bad response of www.nbrb.by/api/exrates/rates/?parammode=2");
            }
            var responseString = response.Result.Content.ReadAsStringAsync();
            var rate = JsonConvert.DeserializeObject<CurrencyResponse>(responseString.Result);
            if (rate.CurScale > 1)
            {
                rate.OfficialRate = rate.OfficialRate / rate.CurScale;
            }

            if (toCurrency == "USD")
            {
                BYNUSDRate = rate.OfficialRate;
                return BYNUSDRate;
            }
            else if (toCurrency == "EUR")
            {
                BYNEURRate = rate.OfficialRate;
                return BYNEURRate;
            }
            else if (toCurrency == "RUB")
            {
                BYNRUBRate = rate.OfficialRate;
                return BYNRUBRate;
            }
            return 0;
        }

        public float Convert(float price, string toCurrency)
        {
            var rate = GetRate(toCurrency);
            return price / rate;
        }
    }
}
