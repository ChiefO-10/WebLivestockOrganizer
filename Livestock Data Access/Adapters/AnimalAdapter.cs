using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using LivestockDataAccess.Models;
using LsOCore.DataContracts;
using LsOCore.RepoContracts;

namespace LivestockDataAccess.Adapters
{
    /// <summary>
    /// CRUD repository for Livestock table
    /// </summary>
    public class AnimalAdapter:IAnimalRepo
    {
        /// <summary>
        /// Connection string via DI
        /// </summary>
        readonly string _connectionString;
        public AnimalAdapter(string cnnString)
        {
            _connectionString = cnnString;
        }
        /// <summary>
        /// Get list of all animals
        /// </summary>
        /// <returns>Collection of Animal</returns>
        public IEnumerable<IAnimal> GetAllAnimals()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                return connection.Query<Animal>("dbo.spGetAllLivestock").ToList();
            }
        }
        /// <summary>
        /// Get single animal by record id
        /// </summary>
        /// <param name="id">Record id</param>
        /// <returns>Single Animal</returns>
        public IAnimal GetAnimalById(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Animal>($"spGetAnimalById @Id", new { Id = id });
            }
        }
        public void CreateAnimal(IAnimal animal)
        {
            throw new NotImplementedException();
        }
        public void UpdateAnimal(IAnimal animal)
        {
            throw new NotImplementedException();
        }
        public void DeleteAnimal(IAnimal animal)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get single animal by its number
        /// </summary>
        /// <param name="animalNumber">Animal number</param>
        /// <returns>SingleAnimal</returns>
        public List<Animal> GetAnimalByNumber(string animalNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                return connection.Query<Animal>($"spGetAnimalByNumber @AnimalNumber", new { AnimalNumber = animalNumber }).ToList();
            }
        }
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

    }
}
