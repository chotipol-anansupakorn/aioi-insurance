using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aioi_insurance.Models.db
{
    public partial class ContractType
    {
        public ContractType()
        {
            Contracts = new HashSet<Contract>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
