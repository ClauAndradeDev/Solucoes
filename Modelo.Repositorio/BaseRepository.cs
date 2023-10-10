using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repositorio
{
    public class BaseRepository<TEntity>
        where TEntity : BaseModelo
    {
        protected DbContext Context { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }
        public BaseRepository(DbContext context)
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
        public virtual async Task<TEntity> Replace(long id, TEntity model)
        {
            var originalModel = await FindById(id);
            DbSet.Remove(originalModel);
            model.Id = id;
            DbSet.Add(model);
            await Context.SaveChangesAsync();
            return model;
        }
        public virtual async Task Remove(long id)
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
        public virtual async Task<TEntity> FindById(long id)
        {
            return await Task.Run(() =>
            {
                var model = DbSet.FirstOrDefault(e => e.Id == id);
                return model;
            });
        }
    }
}
