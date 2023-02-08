using Microsoft.EntityFrameworkCore;
using SMGBitTransportadora.Infra.Repositorio.Modelos;

namespace SMGBitTransportadora.Infra.Contexto
{
    public class TransportadoraContexto : DbContext
    {
        public TransportadoraContexto(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PlanilhaRepositorio> Planilhas { get; set; }
        //public DbSet<TabelaTaxas> TabelaTaxas { get; set; }
    }
}
