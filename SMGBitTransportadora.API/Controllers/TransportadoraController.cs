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

        [HttpGet("transportadora/CalcularFretePlanilha")]
        public async Task<IActionResult> CalcularFretePlanilha()
        {
            return Ok(await TransportadoraServicoCliente.CalcularFretePlanilha());
        }
    }
}
