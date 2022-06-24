using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aioi_insurance.Models.db
{
    public partial class Customer
    {
        public int Id { get; set; } 
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "กรุณากรอกคำนำหน้า")]
        public int TitleId { get; set; }
        [Required]
        public string CusId { get; set; } = null!;

        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "กรุณากรอกนามสกุล")]
        public string Surname { get; set; } = null!;
        [Required(ErrorMessage = "กรุณากรอกวันเกิด")] 
        public DateTime? Dob { get; set; }
        [Required(ErrorMessage = "กรุณากรอกโทรศัพท์")]
        public string Tel { get; set; } = null!;
        [Required(ErrorMessage = "กรุณากรอกอีเมล์")]
        public string Email { get; set; } = null!;
        public DateTime RegistDate { get; set; }

        public virtual NameTitle? Title { get; set; } = null!;
    }
}
