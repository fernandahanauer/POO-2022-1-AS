using Data.Repositories.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ClienteController
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteController(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            this._repository = clienteRepository;
            this._unitOfWork = unitOfWork;
        }

        //-----------------------------------------------

        [HttpGet("api/v1/clientes")]
        public async Task<IActionResult> GetAllAsync()
        {
             var clienteList = await _repository.GetAllAsync();

            List<ClienteDto> clientesDto = new List<ClienteDto>();

            foreach (Cliente cliente in clienteList)
            {
                var clienteDto = new ClienteDto()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                };

                clientesDto.Add(clienteDto);
            }

            return Ok(clientesDto);
        }

        [HttpGet("api/v1/clientes/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var cliente = await _repository.GetByIdAsync(id);

            if (cliente == null)
                return NotFound();
            else
            {
                var clienteDto = new ClienteDto()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                };

                return Ok(clienteDto);
            }
        }

        [HttpPost("api/v1/clientes")]
        public async Task<IActionResult> PostAsync([FromBody] ClienteViewModelPost model)
        {
            var cliente = new Cliente
            {
                Nome = model.Nome,

            };

            _repository.Save(cliente);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Cliente " + cliente.Nome + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete("api/v1/clientes/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var clienteDel = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (clienteDel == false)
                return NotFound();
            else
                return Ok(id);
        }

        [HttpPatch("api/v1/clientes/{id:int}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ClienteViewModelPatch model)
        {
            var cliente = await _repository.GetByIdAsync(id);

            if (cliente == null)
                return NotFound();
            else
            {
                cliente.Nome = model.Nome;

                _repository.Update(cliente);
                await _unitOfWork.CommitAsync();

                var clienteDto = new ClientDto()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                };

                return Ok(clienteDto);
            }
        }
    }
}