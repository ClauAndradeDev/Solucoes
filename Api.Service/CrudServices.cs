using Api.Mapper;
using Modelo.DTOs;
using Modelo.Entidades;
using Modelo.Service;
using Modelo.Repositorio;

namespace Api.Service
{
    public abstract class CrudServices<TModel, TDto> : CrudService<TModel, TDto>
        where TModel : BaseModelo
        where TDto : BaseModeloDto
    {
        public Mapeamento Mapper { get; set; }
        public CrudServices(BaseRepositorios<TModel> repository, Mapeamento mapper) : base(repository)
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
