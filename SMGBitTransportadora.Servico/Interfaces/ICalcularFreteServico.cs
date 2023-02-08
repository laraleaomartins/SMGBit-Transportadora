using SMGBitTransportadora.Apresentacao.Modelos;
using SMGBitTransportadora.Dominio.Modelos;

namespace SMGBitTransportadora.Servico.Interfaces
{
    public interface ICalcularFreteServico
    {
        Task<List<PlanilhaTela>> CalcularFretePlanilha();
    }
}
