using SMGBitTransportadora.Infra.Repositorio.Modelos;

namespace SMGBitTransportadora.Repositorio.Interfaces
{
    public interface IRepositorioBase<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Search(int? id);
        Task<T> Create(T item);
        Task Delete(int id);
    }
}
