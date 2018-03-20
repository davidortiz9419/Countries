namespace Countries.Models
{
    using Newtonsoft.Json;

    public class RegionalBloc
    {
        #region Properties
        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } 
        #endregion
    }
}