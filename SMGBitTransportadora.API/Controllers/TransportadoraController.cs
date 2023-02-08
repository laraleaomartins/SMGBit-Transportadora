using Microsoft.AspNetCore.Mvc;
using SMGBitTransportadora.Aplicacao.Interfaces;
using SMGBitTransportadora.Dominio.Modelos;
using System.Data;

namespace SMGBitTransportadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportadoraController : ControllerBase
    {
        protected ITransportadoraServicoCliente TransportadoraServicoCliente;
        public TransportadoraController(ITransportadoraServicoCliente transportadoraServicoCliente)
        {
            TransportadoraServicoCliente = transportadoraServicoCliente;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await TransportadoraServicoCliente.GetAll());
        }

        [HttpPost("transportadora/Create")]
        public async Task<IActionResult> Create([FromBody] Planilha planilha)
        {
            await TransportadoraServicoCliente.Create(planilha);
            return Ok();
        }

        [HttpDelete("transportadora/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await TransportadoraServicoCliente.Delete(id);
            return Ok();
        }

        [HttpPost("transportadora/BaixarTabela")]
        public async Task<IActionResult> BaixarTabela(IFormFile file)
        {
            await TransportadoraServicoCliente.BaixarTabela(file);
            return Ok();
        }

        [HttpPost("transportadora/SalvarTabela")]
        public async Task<IActionResult> SalvarTabela(DataTable tabela)
        {
            await TransportadoraServicoCliente.SalvarTabela(tabela);
            return Ok();
        }
    }
}
