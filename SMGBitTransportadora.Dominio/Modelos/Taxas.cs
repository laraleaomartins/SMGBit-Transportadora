using Newtonsoft.Json;

namespace SMGBitTransportadora.Dominio.Modelos
{
    public class Taxas
    {
        //public List<TabelaTaxas> TabelaTaxas { get; set; }
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }
        [JsonProperty(PropertyName = "vehicle_type")]
        public string VehicleType { get; set; }
        [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }
        [JsonProperty(PropertyName = "client")]
        public string Client { get; set; }
    }
}