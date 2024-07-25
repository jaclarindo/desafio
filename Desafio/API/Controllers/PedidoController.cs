using Application.DTOs;
using Application.DTOs.AlterarPedido;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Adiciona um novo pedido.
        /// </summary>
        /// <param name="pedidoRequestDto">Dados do pedido a ser criado.</param>
        /// <returns>O pedido criado.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoRequestDto pedidoRequest)
        {
            var pedido = await _pedidoService.AdicionarPedidoAsync(pedidoRequest);
            if (pedido.HasError())
                return BadRequest(pedido);

            return CreatedAtAction(nameof(Get), new { idPedido = pedido.Data.IdPedido }, pedido);
        }

        /// <summary>
        /// Obtém todos os pedidos.
        /// </summary>
        /// <returns>Lista de pedidos.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pedidos = await _pedidoService.ObterPedidosAsync();
            return Ok(pedidos);
        }

        /// <summary>
        /// Obtém um pedido específico pelo seu ID.
        /// </summary>
        /// <param name="idPedido">ID do pedido a ser recuperado.</param>
        /// <returns>O pedido correspondente ao ID fornecido
        /// Caso tenha registros, retorna 200 OK, caso contrário, retorna 404 Not Found.</returns>
        [HttpGet("{idPedido}")]
        public async Task<IActionResult> Get(int idPedido)
        {
            var pedido = await _pedidoService.ObterPedidoAsync(idPedido);
            if (pedido == null)
                return NotFound();
            return Ok(pedido);
        }

        /// <summary>
        /// Atualiza um pedido específico pelo seu ID.
        /// </summary>
        /// <param name="idPedido">ID do pedido a ser atualizado.</param>
        /// <param name="pedidoRequestDto">Dados atualizados do pedido.</param>
        /// <returns>O pedido atualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AlterarPedidoRequestDto pedidoRequest)
        {
            var pedido = await _pedidoService.AlterarPedidoAsync(pedidoRequest);

            if (pedido.HasError())
                return BadRequest(pedido);

            return Ok(pedido);
        }

        /// <summary>
        /// Remove um pedido específico pelo seu ID.
        /// </summary>
        /// <param name="idPedido">ID do pedido a ser removido.</param>
        /// <returns>Resultado da operação de remoção.</returns>
        [HttpDelete("{idPedido}")]
        public async Task<IActionResult> Delete(int idPedido)
        {
            var result = await _pedidoService.RemoverPedidoAsync(idPedido);
            if (result.HasError())
                return  NotFound(result);
            return Ok(result);
        }
    }
}
