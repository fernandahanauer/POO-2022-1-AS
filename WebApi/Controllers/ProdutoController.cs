using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ProdutoController
    {
        private readonly IProdutoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoController(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            this._repository = produtoRepository;
            this._unitOfWork = unitOfWork;
        }

        //-----------------------------------------------

        [HttpGet("api/v1/produtos")]
        public async Task<IActionResult> GetAllAsync()
        {
 
        }

        [HttpGet("api/v1/produtos/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {

        }

        [HttpPost("api/v1/produtos")]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoViewModel model)
        {
          
        }

        [HttpDelete("api/v1/produtos/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
 
        }

        [HttpPatch("api/v1/produtos/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ProdutoViewModel model)
        {
    
        }

    }
}