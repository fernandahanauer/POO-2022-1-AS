using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class ClienteViewModelPost
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}