using SMGBitTransportadora.Dominio.Modelos;

namespace SMGBitTransportadora.Servico.Interfaces
{
    public interface ITransportadoraServico 
    {
        Task<IEnumerable<Planilha>> GetAll();
        Task<Planilha> Create(Planilha planilha);
        Task Delete(int id);
    }
}
