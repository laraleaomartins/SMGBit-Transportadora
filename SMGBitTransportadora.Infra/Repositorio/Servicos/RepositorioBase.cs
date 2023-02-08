using Microsoft.EntityFrameworkCore;
using SMGBitTransportadora.Infra.Contexto;
using SMGBitTransportadora.Infra.Repositorio.Interfaces;
using SMGBitTransportadora.Infra.Repositorio.Modelos;

namespace SMGBitTransportadora.Infra.Repositorio.Servicos
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : BaseEntity
    {
        protected TransportadoraContexto Contexto;
        protected DbSet<T> DataSet;

        public RepositorioBase(TransportadoraContexto context)
        {
            Contexto = context;
            DataSet = Contexto.Set<T>();
        }

        public async Task<T> Create(T item)
        {
            try
            {
                DataSet.Add(item);
                await Contexto.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível adicionar à tabela - {ex}");
            }
        }

        public async Task Delete(int id)
        {
            var result = DataSet.SingleOrDefault(c => c.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    DataSet.Remove(result);
                    await Contexto.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Não foi possível deletar planilha - {ex}");
                }
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return DataSet.ToList();
        }
    }
}
