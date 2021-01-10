using LsOCore.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LsOCore.RepoContracts
{
    public interface IAnimalRepo
    {
        bool SaveChanges();

        IEnumerable<IAnimal> GetAllAnimals();
        IAnimal GetAnimalById(int id);
        void CreateAnimal(IAnimal animal);
        void UpdateAnimal(IAnimal animal);
        void DeleteAnimal(IAnimal animal);
    }
}
