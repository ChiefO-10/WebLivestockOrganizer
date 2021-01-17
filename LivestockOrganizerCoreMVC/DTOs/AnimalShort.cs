using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LivestockOrganizerCoreMVC.DTOs
{
    public class AnimalShort
    {
        [Display(Name = "Animal Number")]
        public string AnimalNumber { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Mother Number")]
        public string MotherNumber { get; set; }

        [Display(Name = "Father Number")]
        public string FatherNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Herd Number")]
        public string HerdNumber { get; set; }

        [Display(Name = "Passport Serial")]
        public string PassportSerial { get; set; }
    }
}
