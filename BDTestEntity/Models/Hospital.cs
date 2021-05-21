using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BDTestEntity.Models
{
    public partial class Hospital
    {
        public Hospital()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public int? HospitalTypeId { get; set; }

        public virtual HospitalType HospitalType { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
