using AutoMapper;
using Newtonsoft.Json;
using SMGBitTransportadora.Dominio.Extensao;
using SMGBitTransportadora.Dominio.Modelos;
using SMGBitTransportadora.Infra.Repositorio.Modelos;
using SMGBitTransportadora.Servico.Interfaces;
using System.Data;

namespace SMGBitTransportadora.Servico.Servicos
{
    public class SalvarTabelaServico : ISalvarTabelaServico
    {
        protected ITransportadoraServico TransportadoraServico;
        protected IMapper Mapper;

        public SalvarTabelaServico(ITransportadoraServico transportadoraServico, IMapper mapper)
        {
            TransportadoraServico = transportadoraServico;
            Mapper = mapper;
        }

        public async Task SalvarTabela(DataTable tabela)
        {
            var json = JsonConvert.SerializeObject(tabela, Formatting.Indented);
            var jsonCerto = json.Replace("Número Parada", "Paradas");
            var planilhasRepositorio = JsonConvert.DeserializeObject<List<PlanilhaRepositorio>>(jsonCerto);

            foreach (var planilhaRepositorio in planilhasRepositorio)
            {
                var planilha = Mapper.Map<Planilha>(planilhaRepositorio);
                await TransportadoraServico.Create(planilha);
            }
        }
    }
}
