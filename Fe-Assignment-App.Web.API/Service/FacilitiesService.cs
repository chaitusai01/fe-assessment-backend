using FeAssignmentApp.Web.API.Models;
using FeAssignmentApp.Web.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace FeAssignmentApp.Web.API.Service
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IFacilitiesRepository _facilitiesRepo;

        public FacilitiesService(IFacilitiesRepository facilitiesRepo)
        {
           _facilitiesRepo = facilitiesRepo;
        }
        public string CreateFacilities(FacilitiesRequest fq)
        {
            if(fq != null)
            {
                Facilities fl = new Facilities();
                fl.FacilityName = fq.FacilityName;
                fl.FacilityLocation = fq.FacilityLocation;
                _facilitiesRepo.CreateFacilities(fl);
                return "Successfully Created " + fq.FacilityName;
            }
            else 
            {
                return "Empty Input";
            }
        }

        public string DeleteByFacility(FacilitiesRequest fq)
        {
            if (fq == null || fq.Id == null)
            {
                return "Empty Input";
            }
            Facilities fl = new Facilities();
            fl.Id = fq.Id;
            fl.FacilityName = fq.FacilityName;
            fl.FacilityLocation = fq.FacilityLocation;
            
            _facilitiesRepo.DeleteByFacility(fl);
            
            return "Successfully Deleted Facility " + fq.FacilityName;
        }

        public List<FacilitiesResultDTO> GetAllFacilities()
        {
            List<Facilities> flt = _facilitiesRepo.GetAllFacilities().ToList();

            var frd =  flt.Select(f => new FacilitiesResultDTO
            {
                FacilityName = f.FacilityName,
                FacilityLocation = f.FacilityLocation,
                Id = f.Id
            }).ToList();
            return frd;
        }

        public FacilitiesResultDTO GetFacilitiesById(int id)
        {
            FacilitiesResultDTO frd = new FacilitiesResultDTO();
            if (id == null)
            {
                return frd;
            }

            Facilities fl = _facilitiesRepo.GetFacilitiesById(id);
            if(fl != null)
            {
                frd.Id = fl.Id;
                frd.FacilityName = fl.FacilityName;
                frd.FacilityLocation = fl.FacilityLocation;
            }
            return frd;
        }

        public string UpdateByFacility(FacilitiesRequest fq)
        {
            if (fq == null)
            {
                return "Empty Input";
            }
            Facilities fl = new Facilities();
            fl.Id = fq.Id;
            fl.FacilityName = fq.FacilityName;
            fl.FacilityLocation = fq.FacilityLocation;

            _facilitiesRepo.UpdateByFacility(fl);
            return "Successfully Updated Facility " + fq.FacilityName;
        }

        public void GetResponseMsg(ref HttpResponseMessage responseMsg, dynamic facilitiesResponse)
        {
            switch (responseMsg.StatusCode)
            {
                case HttpStatusCode.OK: //200
                    {
                        facilitiesResponse.Result = responseMsg.IsSuccessStatusCode ? "Success" : "Error";
                        facilitiesResponse.Message = "The request has succeeded.";
                        break;
                    }
                case HttpStatusCode.BadRequest: //400
                    {
                        facilitiesResponse.Result = responseMsg.IsSuccessStatusCode ? "Success" : "Error";
                        facilitiesResponse.Message = "The request cannot be fulfilled due to bad syntax.";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
