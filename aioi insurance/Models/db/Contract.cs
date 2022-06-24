using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aioi_insurance.Models.db
{
    public partial class Contract
    {
        public int Id { get; set; } 
        public string ContractId { get; set; } = null!; 
        [Required]
        [Range(1, 3, ErrorMessage = "กรุณากรอกประเภทประกันภัย")]
        public int TypeId { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "ราคาประกันภัยต้องมากกว่า 0")]
        public double Price { get; set; }
        [Required(ErrorMessage = "กรุณากรอกยี่ห้อรถ")] 
        public string CarBrand { get; set; } = null!;
        [Required(ErrorMessage = "กรุณากรอกรุ่นรถ")]
        public string CarSerie { get; set; } = null!;
        [Required(ErrorMessage = "กรุณากรอกจำนวน cc")]
        public string Cc { get; set; } = null!;
        [Required(ErrorMessage = "กรุณากรอกทะเบียนรถ")]
        public string LicenseNo { get; set; } = null!;
        [Required(ErrorMessage = "กรุณากรอกเบี้ยประกันภัย")]
        [Range(1, double.MaxValue, ErrorMessage = "เบี้ยประกันภัยต้องมากกว่า 0")]
        public double? Premium { get; set; }
        [Required(ErrorMessage = "กรุณากรอกวงเงินเอาประกันภัย")]
        [Range(1, double.MaxValue, ErrorMessage = "วงเงินเอาประกันภัยต้องมากกว่า 0")]
        public double? Limit { get; set; } 
        public string CusId { get; set; } = null!;
        [Required(ErrorMessage = "กรุณากรอกวันเริ่มคุ้มครอง")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "กรุณากรอกวันสิ้นสุดคุ้มครอง")]
        public DateTime? EndDate { get; set; }

        public virtual ContractType? Type { get; set; } = null!;
    }
}
