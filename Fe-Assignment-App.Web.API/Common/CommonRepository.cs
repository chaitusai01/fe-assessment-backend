using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FeAssignmentApp.Web.API.Common
{
    public class CommonRepository<Entity> : ICommonRepository<Entity> where Entity : class
    {
        private readonly AppDbContext _dbContext;
        public CommonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Entity ett)
        {
            _dbContext.Set<Entity>().Add(ett);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<Entity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<Entity> GetAll()
        {
            return _dbContext.Set<Entity>().AsNoTracking();
        }

        public Entity GetById(int id)
        {
            return _dbContext.Set<Entity>().Find(id);
        }

        public void Update(Entity ett)
        {
            _dbContext.Set<Entity>().Update(ett);
            _dbContext.SaveChanges();
        }
    }
}
