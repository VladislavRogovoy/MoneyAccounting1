using Newtonsoft.Json;

namespace BusinessLogicLayer.Temp.Models
{
    public class CurrencyResponse
    {
        [JsonProperty("Cur_OfficialRate")]
        public float OfficialRate { get; set; }
        [JsonProperty("Cur_Scale")]
        public float CurScale { get; set; }
    }
}
