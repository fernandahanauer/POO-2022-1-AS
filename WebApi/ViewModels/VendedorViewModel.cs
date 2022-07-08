using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace WebApi.ViewModels
{
    public class VendedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Bonificacao { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}