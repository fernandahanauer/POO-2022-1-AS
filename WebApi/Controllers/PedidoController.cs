using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {

        List<Pedido> pedidos = new List<Pedido>();
        public PedidoController()
        {
            pedidos.Add(new Pedido{});
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("");
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var pedidoSelecao = pedidos.FirstOrDefault(x => x.Id == id);
            return pedidoSelecao != null 
                ? Ok(pedidoSelecao) 
                : BadRequest("Erro ao buscar o pedido!");
        }
    }
}