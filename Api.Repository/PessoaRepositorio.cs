using Modelo.Contexto;
using Modelo.Entidades;
using Modelo.Repositorios;

namespace Api.Repository
{
    public class PessoaRepositorio : BaseRepositorios<Pessoa>
    {
        public PessoaRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
