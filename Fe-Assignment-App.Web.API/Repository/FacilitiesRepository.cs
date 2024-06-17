using FeAssignmentApp.Web.API.Models;
using System.Linq;
using FeAssignmentApp.Web.API.Common;
using Microsoft.EntityFrameworkCore;

namespace FeAssignmentApp.Web.API.Repository
{
    public class FacilitiesRepository : CommonRepository<Facilities> , IFacilitiesRepository
    {
        private readonly AppDbContext _dbContext;
        public FacilitiesRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateFacilities(Facilities flt)
        {
            _dbContext.Facilities.Add(flt);
            _dbContext.SaveChanges();
        }

        public void DeleteByFacility(Facilities flt)
        {
            var entity = GetById(flt.Id);
            if (entity != null)
            {
                _dbContext.Set<Facilities>().Remove(entity);
                _dbContext.SaveChanges();
            }

        }

        public IQueryable<Facilities> GetAllFacilities()
        {
            return _dbContext.Set<Facilities>().AsNoTracking();
        }

        public Facilities GetFacilitiesById(int id)
        {
            return _dbContext.Set<Facilities>().Find(id);
        }

        public void UpdateByFacility(Facilities flt)
        {
            var entity = GetById(flt.Id);
            if(entity != null)
            {
                _dbContext.Set<Facilities>().Update(entity);
                _dbContext.SaveChanges();
            }

        }
    }
}
