using AutoMapper;
using SMGBitTransportadora.Dominio.Extensao;
using SMGBitTransportadora.Dominio.Modelos;
using SMGBitTransportadora.Infra.Repositorio.Modelos;

namespace SMGBitTransportadora.Infra.Repositorio.Mapeamento
{
    public class ConfiguracaoMapeamento : Profile
    {
        public ConfiguracaoMapeamento()
        {
            CreateMap<Planilha, PlanilhaRepositorio>().ForMember(pr => pr.TipoVeiculo, u => u.MapFrom(p => p.TipoVeiculo.TipoVeiculoEnumParaString()))
                                                      .ForMember(pr => pr.TipoViagem, u => u.MapFrom(p => p.TipoViagem.TipoViagemEnumParaString()));

            CreateMap<PlanilhaRepositorio, Planilha>().ForMember(p => p.TipoVeiculo, u => u.MapFrom(pr => pr.TipoVeiculo.StringParaTipoVeiculoEnum()))
                                                      .ForMember(p => p.TipoViagem, u => u.MapFrom(pr => pr.TipoViagem.StringParaTipoViagemEnum()));
        }
    }
}
