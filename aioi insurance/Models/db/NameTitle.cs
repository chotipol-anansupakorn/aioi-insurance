using System;
using System.Collections.Generic;

namespace aioi_insurance.Models.db
{
    public partial class NameTitle
    {
        public NameTitle()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
