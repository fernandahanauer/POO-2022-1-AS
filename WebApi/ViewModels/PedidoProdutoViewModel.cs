using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace WebApi.ViewModels
{
    public class PedidoProdutoViewModel
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
    }
}