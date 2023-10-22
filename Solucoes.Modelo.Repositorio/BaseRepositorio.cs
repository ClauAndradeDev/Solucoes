using Microsoft.EntityFrameworkCore;
using Solucoes.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Repositorio
{

    public class BaseRepositorio<TEntity>
            where TEntity : BaseModelo
    {
        protected DbContext Context { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }
        public BaseRepositorio(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> Add(TEntity model)
        {
            DbSet.Add(model);
            await Context.SaveChangesAsync();
            return model;
        }
        public virtual async Task<TEntity> Replace(int id, TEntity model)
        {
            var originalModel = await FindById(id);
            //DbSet.Remove(originalModel);
            //model.Id = id;
            //DbSet.Add(model);
            DbSet.Update(model);
            
            await Context.SaveChangesAsync();
            return model;
        }
        public virtual async Task Remove(int id)
        {
            var originalModel = await FindById(id);
            DbSet.Remove(originalModel);
            await Context.SaveChangesAsync();
        }
        public virtual async Task<TEntity[]> All()
        {
            var result = await DbSet.ToArrayAsync();
            return result;
        }
        public virtual async Task<TEntity> FindById(int id)
        {
            return await Task.Run(() =>
            {
                var model = DbSet.FirstOrDefault(e => e.Id == id);
                return model;
            });
        }
    }
}
