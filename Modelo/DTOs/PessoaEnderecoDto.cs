using Modelo.Enums;

namespace Modelo.DTOs
{
    public class PessoaEnderecoDto : BaseModeloCadastroDto
    {
        public int CodPessoa { get; set; }
        public int CodEndereco { get; set; }
        public TipoEnderecoEnum TipoEndereco { get; set; }
    }
}
