using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivestockOrganizerCoreMVC.DTOs
{
    public class AnimalShort
    {
        public string AnimalNumber { get; set; }
        public string Gender { get; set; }
        public string MotherNumber { get; set; }
        public string FatherNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string HerdNumber { get; set; }
        public string PassportSerial { get; set; }
    }
}
