using BusinessLogicLayer.Temp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Temp
{
    public class CurrencyConverter
    {
        private static float BYNUSDRate { get; set; }
        private static float BYNEURRate { get; set; }
        private static float BYNRUBRate { get; set; }
        private CurrencyConverter() { }

        private static CurrencyConverter _converter;

        private static CurrencyConverter GetConverter()
        {
            if (_converter == null)
            {
                _converter = new CurrencyConverter();
            }

            return _converter;
        }

        private void GetRate(string toCurrency)
        {

            var client = new HttpClient();
            var USDResponse = client.GetAsync(String.Format("https://www.nbrb.by/api/exrates/rates/{0}?parammode=2", toCurrency.ToUpper()));
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
            BYNUSDRate = USDRate.OfficialRate;
        }

        public void Convert(float[] prices, string toCurrency)
        {
            
        }
    }
}
