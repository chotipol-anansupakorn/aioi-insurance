using aioi_insurance.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using aioi_insurance.Models.db;
using aioi_insurance.Models.viewModel;
using System.Linq;

namespace aioi_insurance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AioiContext _context;
        public HomeController(ILogger<HomeController> logger, AioiContext context)
        {
            _logger = logger;
            _context = context;
        }
         
        public IActionResult Index()
        {
            var Contractlist = GetAllData();

            return View(Contractlist.ToList());
        }
        [HttpGet]
        public IActionResult Index(string SearchString)
        { 
            var Contractlist = GetAllData();

            if (!String.IsNullOrEmpty(SearchString))
            { 
                string[] SearchArray = SearchString.Split(" ");
                SearchString = SearchString.Trim(); 
                  
                if (Contractlist.Where(s => s.Contract!.ContractId.Contains(SearchString)).Any())
                {
                    Contractlist = Contractlist.Where(s => s.Contract!.ContractId.Contains(SearchString));
                }

                if (Contractlist.Where(s => s.Customer!.Name.Contains(SearchString) || s.Customer!.Surname.Contains(SearchString)).Any())
                {
                    Contractlist = Contractlist.Where(s => s.Customer!.Name.Contains(SearchString) || s.Customer!.Surname.Contains(SearchString));
                }

               else if (Contractlist.Where(s => s.Customer!.Name.Contains(SearchArray[0]) && s.Customer!.Surname.Contains(SearchArray[1])).Any())
                {
                    Contractlist = Contractlist.Where(s => s.Customer!.Name.Contains(SearchArray[0]) && s.Customer!.Surname.Contains(SearchArray[1]));
                }

                if (Contractlist.Where(s => s.Customer!.Tel.Contains(SearchString)).Any())
                {
                    Contractlist = Contractlist.Where(s => s.Customer!.Tel.Contains(SearchString));
                }

                if (Contractlist.Where(s => s.Contract!.CusId.Contains(SearchString)).Any())
                {
                    Contractlist = Contractlist.Where(s => s.Contract!.CusId.Contains(SearchString));
                }

                if (Contractlist.Where(s => s.Customer!.Email.Contains(SearchString)).Any())
                {
                    Contractlist = Contractlist.Where(s => s.Customer!.Email.Contains(SearchString));
                }

            }
            return View(Contractlist); 
        }

        // GET: Home/Details/5
        public IActionResult Detail(string Id)
        {
            var Contractlist = GetAllData(Id);
          
            return View(Contractlist);
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IEnumerable<ContractDetail> GetAllData()
        {
            var Contractlist = from con in _context.Contracts
                               join type in _context.ContractTypes
                               on con.TypeId equals type.TypeId into table1
                               from type in table1.DefaultIfEmpty()
                               join cus in _context.Customers
                               on con.CusId equals cus.CusId into table2
                               from cus in table2.DefaultIfEmpty()
                               join title in _context.NameTitles
                               on cus.TitleId equals title.Id into table3
                               from title in table3.DefaultIfEmpty()
                               select new ContractDetail
                               {
                                   Contract = con,
                                   ContractType = type,
                                   Customer = cus,
                                   NameTitle = title,

                               };
            return Contractlist.ToList();
        }
        public IEnumerable<ContractDetail> GetAllData(string Id)
        {
            var Contractlist = from con in _context.Contracts
                               join type in _context.ContractTypes
                               on con.TypeId equals type.TypeId into table1
                               from type in table1.DefaultIfEmpty()
                               join cus in _context.Customers
                               on con.CusId equals cus.CusId into table2
                               from cus in table2.DefaultIfEmpty()
                               join title in _context.NameTitles
                               on cus.TitleId equals title.Id into table3
                               from title in table3.DefaultIfEmpty()
                               where con.ContractId == Id
                               select new ContractDetail
                               {
                                   Contract = con,
                                   ContractType = type,
                                   Customer = cus,
                                   NameTitle = title,

                               };
            return Contractlist.ToList();
        }
         
    }
}