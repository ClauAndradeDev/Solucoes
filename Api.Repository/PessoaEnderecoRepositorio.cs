using Modelo.Contexto;
using Modelo.Entidades;
using Modelo.Repositorios;

namespace Api.Repository
{
    public class PessoaEnderecoRepositorio : BaseRepositorios<PessoaEndereco>
    {
        public PessoaEnderecoRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
