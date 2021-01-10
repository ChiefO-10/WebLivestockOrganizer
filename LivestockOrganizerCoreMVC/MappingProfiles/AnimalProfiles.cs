using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LivestockDataAccess.Models;
using LivestockOrganizerCoreMVC.Models;
using LsOCore.DataContracts;

namespace LivestockOrganizerCoreMVC.MappingProfiles
{
    public class AnimalProfiles: Profile
    {
        public AnimalProfiles()
        {
            CreateMap<IAnimal, AnimalModel>();
        }
    }
}
