using Modelo.Enums;

namespace Modelo.Entidades
{
    public class Usuario : BaseModeloCadastro
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public AcessoEnum Acesso { get; set; }
        public int IdPessoa { get; set; }
        public int IdEmpresa { get; set; }
    }
}
