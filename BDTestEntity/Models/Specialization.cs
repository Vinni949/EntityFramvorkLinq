using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BDTestEntity.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string TitleSpecialization { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
