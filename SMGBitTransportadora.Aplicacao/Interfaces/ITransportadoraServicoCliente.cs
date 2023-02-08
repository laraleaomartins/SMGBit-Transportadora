using Microsoft.AspNetCore.Http;
using SMGBitTransportadora.Apresentacao.Modelos;
using SMGBitTransportadora.Dominio.Modelos;
using System.Data;

namespace SMGBitTransportadora.Aplicacao.Interfaces
{
    public  interface ITransportadoraServicoCliente
    {
        Task<List<PlanilhaTela>> CalcularFretePlanilha();
        Task<DataTable> BaixarTabela(IFormFile file);
        Task SalvarTabela(DataTable tabela);
    }
}
