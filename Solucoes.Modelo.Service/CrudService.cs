using Solucoes.Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Service
{

    public abstract class CrudService<TModel, TDto>
            where TModel : BaseModelo
            where TDto : BaseModeloDto
    {

        protected BaseRepositorio<TModel> Repositorio { get; private set; }
        public CrudService(BaseRepositorio<TModel> repositorio)
        {
            Repositorio = repositorio;
        }

        protected abstract TModel DtoToModel(TDto obj);
        protected abstract TDto ModelToDto(TModel obj);

        protected abstract TDto[] ModelsToDtos(TModel[] objs);

        public virtual async Task<TDto> Insert(TDto obj)
        {
            var model = DtoToModel(obj);
            var modelAdd = await Repositorio.Add(model);
            var result = ModelToDto(modelAdd);
            return result;
        }

        public virtual async Task<TDto> Update(int codigo, TDto obj)
        {
            var model = DtoToModel(obj);
            var modelReplaced = await Repositorio.Replace(codigo, model);
            var result = ModelToDto(modelReplaced);
            return result;
        }

        public virtual async Task Delete(int codigo)
        {
            await Repositorio.Remove(codigo);
        }

        public virtual async Task<TDto> FindByCodigo(int codigo)
        {
            var model = await Repositorio.FindById(codigo);
            var result = ModelToDto(model);
            return result;
        }

        public virtual async Task<TDto[]> All()
        {
            var models = await Repositorio.All();
            var result = ModelsToDtos(models);
            return result;
        }

        public virtual async Task<TModel> ReturnModel(int id)
        {
            var result = await Repositorio.FindById(id);
            return result;
        }
    }

}
