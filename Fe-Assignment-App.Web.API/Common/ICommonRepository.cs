using System;
using System.Linq;

namespace FeAssignmentApp.Web.API.Common
{
    public interface ICommonRepository<Entity>
        where Entity : class
    { 
        IQueryable<Entity> GetAll();
        Entity GetById(int id);
        void Create(Entity ett);
        void Update(Entity ett);
        void Delete(int id);
    }
}
