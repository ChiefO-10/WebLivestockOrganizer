using LsOCore.DataContracts;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LivestockOrganizerCoreMVC.Models
{
    public class AnimalModel : IAnimal
    {
        public int Id { get; set; }
        [DisplayName ("Animal Number")]
        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        public string AnimalNumber { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DisplayName("Gender")]
        [Required]
        [RegularExpression(@"^(Female|Male)$")]
        public string Gender { get; set; }
        [DisplayName("Mother Number")]
        public string MotherNumber { get; set; }
        [DisplayName("Father Number")]
        public string FatherNumber { get; set; }
        [DisplayName("Date Of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Herd Number")]
        public string HerdNumber { get; set; }
        [DisplayName("Place Of Birth")]
        public string PlaceOfBirth { get; set; }
        [DisplayName("Passport Serial")]
        public string PassportSerial { get; set; }
        [DisplayName("Passport Date")]
        [DataType(DataType.Date)]
        public DateTime PassportDate { get; set; }
    }
}
