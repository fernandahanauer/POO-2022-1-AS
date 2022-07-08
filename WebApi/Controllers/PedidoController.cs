using Data.Repositories.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoController(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
        {
            this._repository = pedidoRepository;
            this._unitOfWork = unitOfWork;
        }

        //-----------------------------------------------

        [HttpGet("api/v1/pedidos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var pedidosList = await _repository.GetAllAsync();

            List<PedidoDto> pedidosDto = new List<PedidoDto>();

            foreach (Pedido pedido in pedidosList)
            {
                var pedidoDto = new PedidoDto()
                {
                    Id = pedido.Id,
                    DataCompra = pedido.DataCompra,
                    ValorTotal = pedido.ValorTotal,
                };

                pedidosDto.Add(pedidoDto);
            }

            return Ok(pedidosDto);
        }

        [HttpGet("api/v1/pedidos/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var pedido = await _repository.GetByIdAsync(id);

            if (pedido == null)
                return NotFound();
            else
            {
                var pedidoDto = new PedidoDto()
                {
                    Id = pedido.Id,
                    DataCompra = pedido.DataCompra,
                    ValorTotal = pedido.ValorTotal,
                };

                return Ok(pedidoDto);
            }
        }

        [HttpPost("api/v1/pedidos")]
        public async Task<IActionResult> PostAsync([FromBody] PedidoViewModel model)
        {
            var pedido = new Pedido
            {
                DataCompra = model.DataCompra,
                ValorTotal = model.ValorTotal,
            };
            _repository.Save(pedido);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Pedido " + pedido.Id + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("api/v1/pedidos/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var pedidoDel = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (pedidoDel == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("api/v1/pedidos/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] PedidoViewModel model)
        {
            var pedido = await _repository.GetByIdAsync(id);

            if (pedido == null)
                return NotFound();
            else
            {
                pedido.DataCompra = model.DataCompra;
                pedido.ValorTotal = model.ValorTotal;

                _repository.Update(pedido);
                await _unitOfWork.CommitAsync();

                var pedidoDto = new PedidoDto()
                {
                    Id = pedido.Id,
                    DataCompra = pedido.DataCompra,
                    ValorTotal = pedido.ValorTotal
                };

                return Ok(pedidoDto);
            }
        }
    }
}