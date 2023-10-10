using Modelo.DTOs;
using Modelo.Entidades;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Service
{
    public abstract class CrudService<TModel, TDto>
        where TModel: BaseModelo
        where TDto: BaseModeloDto
    {

        protected BaseRepository<TModel> Repository { get; private set; }
        public CrudService(BaseRepository<TModel> repository)
        {
            Repository = repository;
        }

        protected abstract TModel DtoToModel(TDto obj);
        protected abstract TDto ModelToDto(TModel obj);

        protected abstract TDto[] ModelsToDtos(TModel[] objs);

        public virtual async Task<TDto> Insert(TDto obj)
        {
            var model = DtoToModel(obj);
            var modelAdd = await Repository.Add(model);
            var result = ModelToDto(modelAdd);
            return result;
        }

        public virtual async Task<TDto> Update(long codigo, TDto obj)
        {
            var model = DtoToModel(obj);
            var modelReplaced = await Repository.Replace(codigo, model);
            var result = ModelToDto(modelReplaced);
            return result;
        }

        public virtual async Task Delete(long codigo)
        {
            await Repository.Remove(codigo);
        }

        public virtual async Task<TDto> FindByCodigo(long codigo)
        {
            var model = await Repository.FindById(codigo);
            var result = ModelToDto(model);
            return result;
        }

        public virtual async Task<TDto[]> All()
        {
            var models = await Repository.All();
            var result = ModelsToDtos(models);
            return result;
        }

        public virtual async Task<TModel> ReturnModel(long id)
        {
            var result = await Repository.FindById(id);
            return result;
        }
    }
}
