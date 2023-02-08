using SMGBitTransportadora.Infra.Repositorio.Modelos;

namespace SMGBitTransportadora.Infra.Repositorio.Interfaces
{
    public interface IRepositorioBase<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T item);
        Task Delete(int id);
    }
}
