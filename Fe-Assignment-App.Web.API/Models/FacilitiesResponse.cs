using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeAssignmentApp.Web.API.Models
{
    public class FacilitiesResponse
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string actionResult { get; set; }
        public string ErrorMessage { get; set; }
        public List<FacilitiesResultDTO> facilitiesResultList { get; set; }

        public FacilitiesResultDTO facilitiesResult { get; set; }
    }
}
