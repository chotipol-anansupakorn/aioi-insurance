using Microsoft.AspNetCore.Mvc;
using aioi_insurance.Models.db;
using aioi_insurance.Models.viewModel;

namespace aioi_insurance.Models.viewModel
{
    public class ContractDetail 
    {
        public Customer? Customer { get; set; }
        public Contract? Contract { get; set; }
        public ContractType? ContractType { get; set; }  
        public NameTitle? NameTitle { get; set; }

    }
}
