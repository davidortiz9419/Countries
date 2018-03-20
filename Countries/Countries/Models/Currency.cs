namespace Countries.Models
{
    using Newtonsoft.Json;

    public class Currency
    {
        #region Properties
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; } 
        #endregion
    }
}