using Data.Entidades;
using System.Collections.Generic;

namespace Data.EF.Interfaces
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        void Save(T Entity);
        IList<T> GetAll();
        void Delete(T entity);
        void Update(T entity);
        T GetEntity(int id);
    }
}
