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

        [HttpPost("BaixarTabela")]
        public async Task<IActionResult> BaixarTabela(IFormFile file)
        {
            try
            {
                await TransportadoraServicoCliente.BaixarTabela(file);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CalcularFretePlanilha")]
        public async Task<IActionResult> CalcularFretePlanilha()
        {
            try
            {
                return Ok(await TransportadoraServicoCliente.CalcularFretePlanilha());

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
