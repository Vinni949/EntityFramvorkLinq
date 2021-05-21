using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BDTestEntity.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            PatientReception = new HashSet<PatientReception>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Experience { get; set; }
        public int? SpecializationId { get; set; }
        public int? Salary { get; set; }
        public int? CategoryId { get; set; }
        public int? HospitalOfficeId { get; set; }
        public int? HospitalId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual HospitalOffice HospitalOffice { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<PatientReception> PatientReception { get; set; }
    }
}
