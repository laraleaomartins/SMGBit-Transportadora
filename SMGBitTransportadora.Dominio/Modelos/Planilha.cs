using Newtonsoft.Json;
using SMGBitTransportadora.Dominio.Enums;

namespace SMGBitTransportadora.Dominio.Modelos
{
    public class Planilha
    {
        [JsonProperty(PropertyName = "Operação")]
        public string Operacao { get; set; }
        public int Paradas { get; set; }
        [JsonProperty(PropertyName = "Número Viagem")]
        public int NumeroViagem { get; set; }
        [JsonProperty(PropertyName = "Data Viagem")]
        public DateTime DataViagem { get; set; }
        public string Destino { get; set; }
        public string Placa { get; set; }
        public string Motorista { get; set; }
        [JsonProperty(PropertyName = "Tipo de Veículo")]
        public TipoVeiculoEnum TipoVeiculo { get; set; }
        [JsonProperty(PropertyName = "Km Rodado")]
        public int KmRodado { get; set; }
        public int Caixas { get; set; }
        [JsonProperty(PropertyName = "Tipo de Viagem")]
        public TipoViagemEnum TipoViagem { get; set; }
    }
}
