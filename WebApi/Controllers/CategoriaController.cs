using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CategoriaController
    {
        private readonly ICategoriaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaController(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
        {
            this._repository = categoriaRepository;
            this._unitOfWork = unitOfWork;
        }

        //-----------------------------------------------

        [HttpGet("api/v1/clientes")]
        public async Task<IActionResult> GetAllAsync()
        {
 
        }

        [HttpGet("api/v1/clientes/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {

        }

        [HttpPost("api/v1/clientes")]
        public async Task<IActionResult> PostAsync([FromBody] ClienteViewModelPost model)
        {
          
        }

        [HttpDelete("api/v1/clientes/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
 
        }

        [HttpPatch("api/v1/clientes/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ClienteViewModelPatch model)
        {
    
        }
    }
}