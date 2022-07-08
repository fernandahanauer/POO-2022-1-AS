using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace WebApi.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public double ValorTotal { get; set; }
        public double ValorTotalDes { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}