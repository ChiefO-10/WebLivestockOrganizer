using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLivestockOrganizer.Models
{
    public class AnimalShortModel
    {
        public string AnimalNumber { get; set; }
        public string Gender { get; set; }
        //[DisplayFormat(DataFormatString = "{0:d}")]
        //[DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string HerdNumber { get; set; }

    }
}