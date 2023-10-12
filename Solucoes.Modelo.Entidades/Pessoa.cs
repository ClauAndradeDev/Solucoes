﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("Pessoa")]
    public class Pessoa: CadastroModelo
    {
        public string? NomeRazaoSocial { get; set; }
        public string? SobreNomeFantasia { get; set; }
        public string? CPFCNPJ { get; set; }
        public string? RGIE { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool WhatsApp { get; set; }
        public bool TipoEmpresa { get; set; }
        public bool TipoUsuario { get; set; }

        public virtual ICollection<Endereco>? Enderecos { get; set; }
        public virtual ICollection<Contato>? Contatos { get; set; }
        public virtual ICollection<Empresa>? Empresas { get; set; }


    }
}
