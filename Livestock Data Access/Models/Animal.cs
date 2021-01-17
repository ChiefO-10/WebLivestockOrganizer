using LsOCore.DataContracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace LivestockDataAccess.Models
{
    public class Animal: IAnimal
    {
        //POCO - Plain Old CLR Object
        public int Id { get; set; }

        [Display(Name = "Animal Number")]
        public string AnimalNumber { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Mother Number")]
        public string MotherNumber { get; set; }

        [Display(Name = "Father Number")]
        public string FatherNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Herd Number")]
        public string HerdNumber { get; set; }

        [Display(Name = "Place Of Birth")]
        public string PlaceOfBirth { get; set; }

        [Display(Name = "Passport Serial")]
        public string PassportSerial { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Passport Date")]
        public DateTime PassportDate { get; set; }

    }
}
