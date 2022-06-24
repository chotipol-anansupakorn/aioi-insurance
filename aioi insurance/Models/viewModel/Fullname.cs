using Microsoft.AspNetCore.Mvc;
using aioi_insurance.Models.db;
using aioi_insurance.Models.viewModel;

namespace aioi_insurance.Models.viewModel
{
    public class Fullname
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Full { get; set; }  

    }
}
