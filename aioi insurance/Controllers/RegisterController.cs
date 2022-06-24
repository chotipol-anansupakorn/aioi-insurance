using Microsoft.AspNetCore.Mvc;
using aioi_insurance.Models.db;
using aioi_insurance.Models.viewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aioi_insurance.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AioiContext _context;
        public string id ="";
        public RegisterController(AioiContext context)
        { 
            _context = context;
        }

        public IActionResult Index()
        { 
            return View();
        } 
       
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer model)
        { 
            if (ModelState.IsValid)
            {
                //Check employee exits?
                var CustomerExist = CheckExist(model);
                if(CustomerExist)
                {
                    id = GetCustomerID(model);

                    ViewData["message"] = "ลูกค้ามีชื่อในระบบแล้ว หมายเลขสมาชิก "+id;
                    TempData["id"] = id;
                    return View();
                }

                //create auto customer id
                 id = CreateCustomerID();
                TempData["id"] = id;
                var customer = new Customer()
                {
                    CusId = id,
                    TitleId = model.TitleId,
                    Name = model.Name,
                    Surname = model.Surname,
                    Dob = model.Dob,
                    Tel = model.Tel,
                    Email = model.Email,
                    RegistDate = DateTime.Now,
                };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                TempData["id"] = id;
                ViewData["message"] = "ลงทะเบียนลูกค้าสำเร็จ หมายเลขสมาชิก " + id;
                return View();
            }

            //error message
            ViewData["message"] = "ลงทะเบียนไม่สำเร็จ"; 
            return View(model);
        }

        public IActionResult CreateContract()
        {
            var data = GetAllType();
            ViewData["type"] = new SelectList(data, "TypeId", "Name");

            var cusid = TempData["id"] as string;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract(Contract model)
        {
            var data = GetAllType();
            ViewData["type"] = new SelectList(data, "TypeId", "Name");

            var cusid = TempData["id"] as string;

            if (ModelState.IsValid)
            {  
                var contract = new Contract()
                {
                    ContractId = model.ContractId,
                    TypeId = model.TypeId, 
                    CusId = cusid,
                    Price = model.Price,
                    CarBrand = model.CarBrand,
                    CarSerie = model.CarSerie,
                    Cc = model.Cc,
                    LicenseNo = model.LicenseNo,
                    Premium = model.Premium,
                    Limit = model.Limit,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                };
                _context.Contracts.Add(contract);
                await _context.SaveChangesAsync();

                ViewData["message"] = "ซื้อกรมธรรณ์สำเร็จ หมายเลขกรมธรรณ์ "+ contract.ContractId;
                return View();
            }
            TempData["id"] = cusid;
            //error message
            ViewData["message"] = "ลงทะเบียนไม่สำเร็จ";
            return View(model);
        }

        public Boolean CheckExist(Customer model)
        {
            //Check employee exits?
            var CustomerExist = from cus in _context.Customers
                                where cus.Name == model.Name &&
                                cus.Surname == model.Surname
                                select cus;
            if (CustomerExist.Any())
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        public string GetCustomerID(Customer model)
        {
            var id = (from a in _context.Customers
                     where a.Name == model.Name &&
                     a.Surname == model.Surname 
                     select a).FirstOrDefault();
            return id.CusId.ToString();
        }
        public IEnumerable<ContractType> GetAllType()
        {
            var data = (from a in _context.ContractTypes
                        select a).ToList();
            return data;
        }
        public string CreateCustomerID()
        {
            var amount = (from cus in _context.Customers
                          where cus.RegistDate.Year == DateTime.Now.Year
                          select cus).Count();
            amount++;

            var id = DateTime.Now.ToString("yyyy") + amount.ToString("D6");
            return id;
        } 
         
    }
}
