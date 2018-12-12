using Data.EF.Interfaces;
using Data.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Data.EF.Repositories
{
    public class BaseRepostiry<T> : IBaseRepository<T> where T : EntidadeBase
    {
        //static readonly Context ctx = new Context();

        public void Delete(T entity)
        {
            using(Context ctx = new Context())
            {
                ctx.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                Salvar(ctx);
            }
        }

        public IList<T> GetAll()
        {
            using (Context ctx = new Context())
            {
                IList<T> list = ctx.Set<T>().ToList();
                return list;
            }
        }

        public T GetEntity(int id)
        {
            using (Context ctx = new Context())
            {
                return ctx.Set<T>().Find();
            }
        }

        public void Save(T entity)
        {
            using (Context ctx = new Context())
            {
                ctx.Set<T>().Add(entity);
                Salvar(ctx);
            }
            
        }

        public void Update(T entity)
        {
            using (Context ctx = new Context())
            {
                ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                Salvar(ctx);
            }
            
        }

        private void Salvar(Context context)
        {
            context.SaveChanges();
        }
    }
}
