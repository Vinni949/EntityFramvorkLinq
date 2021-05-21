using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BDTestEntity.Models
{
    public partial class Patient
    {
        public Patient()
        {
            PatientReception = new HashSet<PatientReception>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public byte? Age { get; set; }
        public string Complaints { get; set; }

        public virtual ICollection<PatientReception> PatientReception { get; set; }
    }
}
