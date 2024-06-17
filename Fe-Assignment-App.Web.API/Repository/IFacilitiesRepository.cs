using FeAssignmentApp.Web.API.Common;
using FeAssignmentApp.Web.API.Models;
using System.Linq;

namespace FeAssignmentApp.Web.API.Repository
{
    public interface IFacilitiesRepository : ICommonRepository<Facilities>
    {
        public void CreateFacilities(Facilities flt);

        public void DeleteByFacility(Facilities flt);

        public IQueryable<Facilities> GetAllFacilities();

        public Facilities GetFacilitiesById(int id);

        public void UpdateByFacility(Facilities flt);

    }
}
