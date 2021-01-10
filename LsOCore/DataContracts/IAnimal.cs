
using System;

namespace LsOCore.DataContracts
{
    public interface IAnimal
    {
        int Id { get; set; }
        string AnimalNumber { get; set; }
        string Country { get; set; }
        string Gender { get; set; }
        string MotherNumber { get; set; }
        string FatherNumber { get; set; }
        DateTime DateOfBirth { get; set; }
        string HerdNumber { get; set; }
        string PlaceOfBirth { get; set; }
        string PassportSerial { get; set; }
        DateTime PassportDate { get; set; }
    }
}
