using AutoMapper;
using SMGBitTransportadora.Dominio.Modelos;
using SMGBitTransportadora.Servico.Interfaces;
using SMGBitTransportadora.Infra.Repositorio.Modelos;
using SMGBitTransportadora.Infra.Repositorio.Interfaces;
using SMGBitTransportadora.Dominio.Extensao;

namespace SMGBitTransportadora.Servico.Servicos
{
    public class TransportadoraServico : ITransportadoraServico
    {
        private readonly IRepositorioBase<PlanilhaRepositorio> Repositorio;
        private readonly IMapper Mapper;

        public TransportadoraServico(IRepositorioBase<PlanilhaRepositorio> repositorio, IMapper mapper)
        {
            Repositorio = repositorio;
            Mapper = mapper;
        }

        public async Task<Planilha> Create(Planilha planilha)
        {
            var planilhaRepositorio = Mapper.Map<PlanilhaRepositorio>(planilha);
            await Repositorio.Create(planilhaRepositorio);
            return planilha;
        }

        public async Task Delete(int id)
        {
            await Repositorio.Delete(id);
        }

        public async Task<IEnumerable<Planilha>> GetAll()
        {
            var planilhaRepositorio = await Repositorio.GetAll();
            var planilha =  Mapper.Map<IEnumerable<Planilha>>(planilhaRepositorio);
            return planilha;
        }
    }
}
