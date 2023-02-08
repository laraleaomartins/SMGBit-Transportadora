using Microsoft.AspNetCore.Http;
using SMGBitTransportadora.Dominio.Modelos;
using System.Data;

namespace SMGBitTransportadora.Aplicacao.Interfaces
{
    public  interface ITransportadoraServicoCliente
    {
        Task<IEnumerable<Planilha>> GetAll();
        Task<Planilha> Create(Planilha planilha);
        Task Delete(int id);
        Task<DataTable> BaixarTabela(IFormFile file);
        Task SalvarTabela(DataTable tabela);
    }
}
