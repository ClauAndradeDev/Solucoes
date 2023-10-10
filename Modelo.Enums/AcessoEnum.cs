using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Enums
{
    public enum AcessoEnum
    {
        ClienteUsuario = 0, //visão apenas dos seus chamados
        ClienteEmpresa = 1, //visão de todos os chamados da empresa
        Adminsitracao = 2, // visão geral de tudo
        Suporte = 3, // visão geral de todos os chamados de todos os clientes do tipo suporte
        Desenvolvimento = 4, //visão geral de todos os chamados de todos os clientes do tipo desenvolvimento
        Financeiro = 5, // visão geral de todos os chamados de todos os clientes do tipo financeiro
        Implantacao = 6  //visão geral de todos os chamados de todos os clientes do tipo implantacao
    }
}
