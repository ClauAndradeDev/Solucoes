using Modelo.Contexto;
using Modelo.Entidades;
using Modelo.Repositorio;

namespace Api.Repository
{
    public class AgendamentoItemRepositorio : BaseRepositorios<AgendamentoItem>
    {
        public AgendamentoItemRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
