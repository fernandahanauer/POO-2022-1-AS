using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Domain.Dtos;
using Domain.Entities;
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
            var produtosList = await _repository.GetAllAsync();

            List<ProdutoDto> produtosDto = new List<ProdutoDto>();

            foreach (Produto produto in produtosList)
            {
                {
                    var produtoDto = new ProdutoDto()
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Preco = produto.Preco,
                    };
                    ProdutoDto.Add(produtosDto);

                }

                return Ok(produtosDto);
            }
        }

        [HttpGet("api/v1/produtos/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var produto = await _repository.GetByIdAsync(id);

            if (produto == null)
                return NotFound();
            else
            {
                var produtoDto = new ProdutoDto()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                };
                return Ok(produtoDto);
            }
        }

        [HttpPost("api/v1/produtos")]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoViewModel model)
        {
           var produto = new Produto
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
            };

            _repository.Save(produto);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Produto " + produto.Nome + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("api/v1/produtos/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var produtoDel = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (produtoDel == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("api/v1/produtos/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ProdutoViewModel model)
        {
            var produto = await _repository.GetByIdAsync(id);

            if (produto == null)
                return NotFound();
            else
            {
                produto.Nome = model.Nome;
                produto.Preco = model.Preco;

                _repository.Update(produto);
                await _unitOfWork.CommitAsync();

                var produtoDto = new ProdutoDto()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                };
                return Ok(produtoDto);
            }
        }
    }
}