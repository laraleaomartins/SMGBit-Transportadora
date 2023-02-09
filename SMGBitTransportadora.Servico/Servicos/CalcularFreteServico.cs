using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SMGBitTransportadora.Apresentacao.Modelos;
using SMGBitTransportadora.Dominio.Extensao;
using SMGBitTransportadora.Dominio.Modelos;
using SMGBitTransportadora.Servico.Interfaces;

namespace SMGBitTransportadora.Servico.Servicos
{
    public class CalcularFreteServico : ICalcularFreteServico
    {
        protected ITransportadoraServico TransportadoraServico;
        protected IMapper Mapper;
        public CalcularFreteServico(ITransportadoraServico transportadoraServico, IMapper mapper)
        {
            TransportadoraServico = transportadoraServico;
            Mapper = mapper;
        }

        public async Task<List<PlanilhaTela>> CalcularFretePlanilha()
        {
            string jsonTaxas = @"
                    {
                        ""table_1"": {
                        ""value"": 900,
                        ""vehicle_type"": ""VUC"",
                        ""client"": ""CDD Ribeirão Preto""
                        },
                        ""table_2"": {
                        ""value"": 812,
                        ""vehicle_type"": ""CARRETA"",
                        ""client"": ""CDD Ribeirão Preto""
                        },
                        ""table_3"": {
                        ""value"": 687,
                        ""vehicle_type"": ""VAN"",
                        ""client"": ""CDD Ribeirão Preto""
                        },
                        ""table_4"": {
                        ""value"": 702,
                        ""vehicle_type"": ""TRUCK"",
                        ""client"": ""CDD Ribeirão Preto""
                        },
                        ""table_5"": {
                        ""value"": 702,
                        ""vehicle_type"": ""TRUCK"",
                        ""destination"": ""Regiao 2"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_6"": {
                        ""value"": 698,
                        ""vehicle_type"": ""TRUCK"",
                        ""destination"": ""Regiao 10"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_7"": {
                        ""value"": 900,
                        ""vehicle_type"": ""TRUCK"",
                        ""destination"": ""Regiao 7"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_8"": {
                        ""value"": 777,
                        ""vehicle_type"": ""TRUCK"",
                        ""destination"": ""Regiao 3"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_9"": {
                        ""value"": 532,
                        ""vehicle_type"": ""VUC"",
                        ""destination"": ""Regiao 3"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_10"": {
                        ""value"": 502,
                        ""vehicle_type"": ""VUC"",
                        ""destination"": ""Regiao 2"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_11"": {
                        ""value"": 478,
                        ""vehicle_type"": ""VUC"",
                        ""destination"": ""Regiao 10"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_12"": {
                        ""value"": 690,
                        ""vehicle_type"": ""VUC"",
                        ""destination"": ""Regiao 7"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_13"": {
                        ""value"": 300,
                        ""vehicle_type"": ""VAN"",
                        ""destination"": ""Regiao 7"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_14"": {
                        ""value"": 412,
                        ""vehicle_type"": ""VAN"",
                        ""destination"": ""Regiao 2"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_15"": {
                        ""value"": 400,
                        ""vehicle_type"": ""VAN"",
                        ""destination"": ""Regiao 3"",
                        ""client"": ""CDD São Paulo""
                        },
                        ""table_16"": {
                        ""value"": 541,
                        ""vehicle_type"": ""VAN"",
                        ""destination"": ""Regiao 10"",
                        ""client"": ""CDD São Paulo""
                        }
            }";


            List<Taxas> taxas = new List<Taxas>(); 
            JObject jsonObject = JObject.Parse(jsonTaxas);
            foreach (var property in jsonObject.Properties())
            {
                Taxas taxa = JsonConvert.DeserializeObject<Taxas>(property.Value.ToString());
                taxas.Add(taxa);
            }

            var planilhasDominio = await TransportadoraServico.GetAll(); 

            List<PlanilhaTela> planilhaTela = new List<PlanilhaTela>();

            foreach(var planilhaDominio in planilhasDominio)
            {
                foreach(var taxa in taxas)
                {
                    if(planilhaDominio.Destino == taxa.Destination && planilhaDominio.TipoVeiculo.TipoVeiculoEnumParaString().ToUpper() == taxa.VehicleType && planilhaDominio.Operacao == taxa.Client)
                    {
                        var planilhaParaTela = Mapper.Map<PlanilhaTela>(planilhaDominio);
                        planilhaParaTela.Taxa = taxa.Value;
                        planilhaTela.Add(planilhaParaTela);
                    }
                    if (taxa.Destination == null && planilhaDominio.TipoVeiculo.TipoVeiculoEnumParaString().ToUpper() == taxa.VehicleType && planilhaDominio.Operacao == taxa.Client)
                    {
                        var planilhaParaTela = Mapper.Map<PlanilhaTela>(planilhaDominio);
                        planilhaParaTela.Taxa = taxa.Value;
                        planilhaTela.Add(planilhaParaTela);
                    }
                }
            }
            return planilhaTela;
        }
    }
}
