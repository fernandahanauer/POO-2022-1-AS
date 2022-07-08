
using Data.Repositories.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

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
            var categoriasList = await _repository.GetAllAsync();

            List<CategoriaDto> categoriasDto = new List<CategoriaDto>();

            foreach (Categoria categoria in categoriasList)
            {
                var categoriaDto = new CategoriaDto()
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                };

                categoriasDto.Add(categoriaDto);
            }

            return Ok(categoriasDto);
        }

        [HttpGet("api/v1/clientes/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
                return NotFound();
            else
            {
                var categoriaDto = new CategoriaDto()
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };

                return Ok(categoriaDto);
            }
        }

        [HttpPost("api/v1/clientes")]
        public async Task<IActionResult> PostAsync([FromBody] CategoriaViewModel model)
        {
            var categoria = new Categoria
            {
                Nome = model.Nome
            };

            _repository.Save(categoria);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Categoria " + categoria.Nome + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("api/v1/clientes/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var categoriaDel = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (categoriaDel == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("api/v1/clientes/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] CategoriaViewModel model)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null)
                return NotFound();
            else
            {
                categoria.Nome = model.Nome;


                _repository.Update(categoria);
                await _unitOfWork.CommitAsync();

                var categoriaDto = new CategoriaDto()
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                };

                return Ok(categoriaDto);
            }
        }
    }
}