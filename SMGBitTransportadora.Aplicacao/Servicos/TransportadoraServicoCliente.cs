using Microsoft.AspNetCore.Http;
using SMGBitTransportadora.Aplicacao.Interfaces;
using SMGBitTransportadora.Apresentacao.Modelos;
using SMGBitTransportadora.Servico.Interfaces;
using System.Data;

namespace SMGBitTransportadora.Aplicacao.Servicos
{
    public class TransportadoraServicoCliente : ITransportadoraServicoCliente
    {
        protected ISalvarTabelaServico SalvarTabelaServico;
        protected IBaixarTabelaServico BaixarTabelaServico;
        protected ICalcularFreteServico CalcularFreteServico;
        public TransportadoraServicoCliente(ISalvarTabelaServico salvarTabelaServico, IBaixarTabelaServico baixarTabelaServico, ICalcularFreteServico calcularFreteServico)
        {
            SalvarTabelaServico = salvarTabelaServico;
            BaixarTabelaServico = baixarTabelaServico;
            CalcularFreteServico = calcularFreteServico;
        }

        public async Task<DataTable> BaixarTabela(IFormFile file)
        {
            var tabela = await BaixarTabelaServico.BaixarTabela(file);
            await SalvarTabela(tabela);
            return tabela;
        }

        public async Task<List<PlanilhaTela>> CalcularFretePlanilha()
        {
            return await CalcularFreteServico.CalcularFretePlanilha();
        }

        public async Task SalvarTabela(DataTable tabela)
        {
            await SalvarTabelaServico.SalvarTabela(tabela);
        }
    }
}
