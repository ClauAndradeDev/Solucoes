using Modelo.Enums;

namespace Modelo.DTOs
{
    public class UsuarioDto : BaseModeloCadastroDto
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public AcessoEnum Acesso { get; set; }
        public int CodPessoa { get; set; }
        public int CodEmpresa { get; set; }
    }
}
