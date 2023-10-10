using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Pessoa : BaseModeloCadastro
    {
        public string? NomeRazaoSocial { get; set; }
        public string? SobreNomeFantasia { get; set; }
        public string? CPFCNPJ { get; set; }
        public string? RGIE { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool WhatsApp { get; set; }

    }
}
