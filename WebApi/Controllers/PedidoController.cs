using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
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
 
        }

        [HttpGet("api/v1/pedidos/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {

        }

        [HttpPost("api/v1/pedidos")]
        public async Task<IActionResult> PostAsync([FromBody] PedidoViewModel model)
        {
          
        }

        [HttpDelete("api/v1/pedidos/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
 
        }

        [HttpPatch("api/v1/pedidos/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] PedidoViewModel model)
        {
    
        }
    }
}