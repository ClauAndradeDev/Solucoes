using Solucoes.Api.Mapper;
using Solucoes.Modelo;
using Solucoes.Modelo.Repositorio;
using Solucoes.Modelo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service
{
    public abstract class CrudServices<TModel, TDto> : CrudService<TModel, TDto>
        where TModel : BaseModelo
        where TDto : BaseModeloDto
    {
        public Mapper.Mapper Mapper { get; set; }
        public CrudServices(BaseRepositorio<TModel> repository, Mapper.Mapper mapper) : base(repository)
        {
            Mapper = mapper;
        }

        protected override TModel DtoToModel(TDto obj)
        {
            var result = Mapper.Map<TModel>(obj);
            return result;
        }

        protected override TDto ModelToDto(TModel obj)
        {
            var result = Mapper.Map<TDto>(obj);
            return result;
        }

        protected override TDto[] ModelsToDtos(TModel[] objs)
        {
            var result = Mapper.Map<TDto[]>(objs);
            return result;
        }
    }
}
