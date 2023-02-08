using Newtonsoft.Json;
using SMGBitTransportadora.Dominio.Enums;

namespace SMGBitTransportadora.Dominio.Modelos
{
    public class TabelaTaxas
    {
        [JsonProperty(PropertyName = "value")]
        public int Valor { get; set; }
        [JsonProperty(PropertyName = "vehicle_type")]
        public TipoVeiculoEnum TipoVeiculo { get; set; }
        [JsonProperty(PropertyName = "client")]
        public int Cliente { get; set; }
    }
}
