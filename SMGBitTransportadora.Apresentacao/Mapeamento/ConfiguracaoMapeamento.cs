using AutoMapper;
using SMGBitTransportadora.Apresentacao.Modelos;
using SMGBitTransportadora.Dominio.Modelos;

namespace SMGBitTransportadora.Apresentacao.Mapeamento
{
    public class ConfiguracaoMapeamento : Profile
    {
        public ConfiguracaoMapeamento()
        {
            CreateMap<Planilha, PlanilhaTela>();

        }
    }
}
