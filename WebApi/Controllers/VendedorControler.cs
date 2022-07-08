using Domain.Dtos;
using Domain.Entities;
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
            var vendedoresList = await _repository.GetAllAsync();

            List<VendedorDto> vendedoresDto = new List<VendedorDto>();

            foreach (Vendedor vendedor in vendedoresList)
            {
                var vendedorDto = new VendedorDto()
                {
                    Id = vendedor.Id,
                    Nome = vendedor.Nome,
                    Bonificacao = vendedor.Bonificacao
                };

                vendedoresDto.Add(vendedorDto);
            }

            return Ok(vendedoresDto);
        }

        [HttpGet("api/v1/vendedores/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var vendedor = await _repository.GetByIdAsync(id);

            if (vendedor == null)
                return NotFound();
            else
            {
                var vendedorDto = new VendedorDto()
                {
                    Id = vendedor.Id,
                    Nome = vendedor.Nome,
                    Bonificacao = vendedor.Bonificacao
                };

                return Ok(vendedorDto);
            }
        }

        [HttpPost("api/v1/vendedores")]
        public async Task<IActionResult> PostAsync([FromBody] VendedorViewModel model)
        {
            var vendedor = new Vendedor
            {
                Nome = model.Nome,
                Bonificacao = model.Bonificacao
            };

            _repository.Save(vendedor);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Vendedor " + vendedor.Nome + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("api/v1/vendedores/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var vendedorDel = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (vendedorDel == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("api/v1/vendedores/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] VendedorViewModel model)
        {
            var vendedor = await _repository.GetByIdAsync(id);

            if (vendedor == null)
                return NotFound();
            else
            {
                vendedor.Nome = model.Nome;
                vendedor.Bonificacao = model.Bonificacao;

                _repository.Update(vendedor);
                await _unitOfWork.CommitAsync();

                var vendedorDto = new VendedorDto()
                {
                    Id = vendedor.Id,
                    Nome = vendedor.Nome,
                    Bonificacao = vendedor.Bonificacao,
                };

                return Ok(vendedorDto);
            }
        }
    }
}