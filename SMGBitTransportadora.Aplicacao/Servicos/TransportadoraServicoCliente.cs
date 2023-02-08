using Microsoft.AspNetCore.Http;
using SMGBitTransportadora.Aplicacao.Interfaces;
using SMGBitTransportadora.Dominio.Modelos;
using SMGBitTransportadora.Servico.Interfaces;
using System.Data;

namespace SMGBitTransportadora.Aplicacao.Servicos
{
    public class TransportadoraServicoCliente : ITransportadoraServicoCliente
    {
        protected ITransportadoraServico TransportadoraServico;
        protected ISalvarTabelaServico SalvarTabelaServico;
        protected IBaixarTabelaServico BaixarTabelaServico;
        public TransportadoraServicoCliente(ITransportadoraServico transportadoraServico, ISalvarTabelaServico salvarTabelaServico, IBaixarTabelaServico baixarTabelaServico)
        {
            TransportadoraServico = transportadoraServico;
            SalvarTabelaServico = salvarTabelaServico;
            BaixarTabelaServico = baixarTabelaServico;
        }

        public async Task<DataTable> BaixarTabela(IFormFile file)
        {
            var tabela = await BaixarTabelaServico.BaixarTabela(file);
            await SalvarTabela(tabela);
            return tabela;
        }

        public async Task<Planilha> Create(Planilha planilha)
        {
            await TransportadoraServico.Create(planilha);
            return planilha;
        }

        public async  Task Delete(int id)
        {
            await TransportadoraServico.Delete(id);
        }

        public async Task<IEnumerable<Planilha>> GetAll()
        {
            var planilhas = await TransportadoraServico.GetAll();
            return planilhas;
        }

        public async Task SalvarTabela(DataTable tabela)
        {
            await SalvarTabelaServico.SalvarTabela(tabela);
        }
    }
}
