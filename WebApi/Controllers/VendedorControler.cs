using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorControler : ControllerBase
    {
        private readonly IVendedorRepository _repository;

        public VendedorControler(IVendedorRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _repository.GetVendedoresAsync();
            return pacientes.Any()
            ? Ok(pacientes)
            : NotFound("Vendedores não encontrados.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id <= 0) return BadRequest("Vendedor inválido");

            var vendedor = await _repository.GetVendedorByIdAsync(id);

            return vendedor != null
                ? Ok(vendedor)
                : NotFound("Vendedor não existe na base de.");

        }



    }
}