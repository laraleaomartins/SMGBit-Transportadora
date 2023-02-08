using SMGBitTransportadora.Dominio.Modelos;

namespace SMGBitTransportadora.Servico.Interfaces
{
    public interface ITransportadoraServico 
    {
        Task<List<Planilha>> GetAll();
        Task<Planilha> Create(Planilha planilha);
    }
}
