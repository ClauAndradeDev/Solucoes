using Modelo.Enums;

namespace Modelo.Entidades
{
    public class PessoaEndereco : BaseModeloCadastro
    {
        public int IdPessoa { get; set; }
        public int IdEndereco { get; set; }
        public TipoEnderecoEnum TipoEndereco { get; set; }
    }
}
