﻿using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("Empresa")]
    public class Empresa: CadastroModelo
    {
        public string? NomeRazaoSocial { get; set; }
        public string? SobreNomeFantasia { get; set; }
        public string? CPFCNPJ { get; set; }
        public string? RGIE { get; set; }
        public DateTime DataAbertura { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool WhatsApp { get; set; }
        public string? IEMunicipal { get; set; }
        public TipoPessoaEnumcs TipoEmpresa { get; set; }


        public virtual ICollection<Endereco>? Enderecos { get; set; }
        public virtual ICollection<Pessoa>? Pessoas { get; set; }
        public virtual ICollection<SetorEmpresa>? Setores { get; set; }

    }
}
