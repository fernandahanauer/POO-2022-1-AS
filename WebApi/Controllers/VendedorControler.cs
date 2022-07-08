using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public VendedorController(IVendedorRepository vendedorRepository, IUnitOfWork unitOfWork)
        {
            this._repository = vendedorRepository;
            this._unitOfWork = unitOfWork;
        }

        //-----------------------------------------------

        [HttpGet("api/v1/vendedores")]
        public async Task<IActionResult> GetAllAsync()
        {
 
        }

        [HttpGet("api/v1/vendedores/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {

        }

        [HttpPost("api/v1/vendedores")]
        public async Task<IActionResult> PostAsync([FromBody] VendedorViewModel model)
        {
          
        }

        [HttpDelete("api/v1/vendedores/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
 
        }

        [HttpPatch("api/v1/vendedores/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] VendedorViewModel model)
        {
    
        }

    }
}