using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BDTestEntity.Models
{
    public partial class Category
    {
        public Category()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string TitleСategory { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
