using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class VendedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Bonificacao { get; set; }
    }
}