using FeAssignmentApp.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeAssignmentApp.Web.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey("Facilities")]
        public int FacilityId { get; set; }
        public virtual Facilities Facilities{ get; set; }

        public string PhysicianName { get; set; }

        public string EmailId { get; set; }

        public int AmountDue { get; set; }

        public string ServiceType { get; set; }

        public Patient() {}
    }
}
