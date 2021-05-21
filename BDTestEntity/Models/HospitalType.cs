using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BDTestEntity.Models
{
    public partial class HospitalType
    {
        public HospitalType()
        {
            Hospital = new HashSet<Hospital>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Hospital> Hospital { get; set; }
    }
}
