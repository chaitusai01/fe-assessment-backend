using FeAssignmentApp.Web.API.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace FeAssignmentApp.Web.API.Service
{
    interface IFacilitiesService
    {
        public List<FacilitiesResultDTO> GetAllFacilities();

        public string CreateFacilities(FacilitiesRequest fq);

        public string DeleteByFacility(FacilitiesRequest fq);

        public FacilitiesResultDTO GetFacilitiesById(int id);

        public string UpdateByFacility(FacilitiesRequest fq);

        void GetResponseMsg(ref HttpResponseMessage responseMsg, dynamic issuesResponse);
    }
}
