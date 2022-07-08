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

            List<ClienteDto> clienteDTO = new List<ClienteDto>();

            foreach (Cliente cliente in clienteList)
            {
                var clienteDto = new ClienteDto()
                {
                    Id = cliente.Id,
                    Name = cliente.Name,
e
                };

                clientsDTO.Add(clientDTO);
            }

            return Ok(clientsDTO);
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