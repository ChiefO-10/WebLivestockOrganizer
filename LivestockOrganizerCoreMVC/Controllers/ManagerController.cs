using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using LivestockOrganizerCoreMVC.Models;
using LsOCore.DataContracts;
using LsOCore.RepoContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivestockOrganizerCoreMVC.Controllers
{
    public class ManagerController : Controller
    {
        readonly IAnimalRepo _repository;
        readonly IMapper _mapper;
        public ManagerController(IAnimalRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Manager
        [HttpGet]
        public ActionResult Animals([FromQuery] AnimalModel searchAnimal)
        {
            try
            {
                ViewBag.Message = "Short herd summary";
                var animalcollection = _repository.GetAllAnimals();

                var animalModelCollection = _mapper.Map<IEnumerable<AnimalModel>>(animalcollection);

                foreach (PropertyInfo property in searchAnimal.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    try
                    {
                        var propval = property.GetValue(searchAnimal);
                        if (propval == null) continue;
                        if (String.IsNullOrWhiteSpace(propval.ToString()) == false && propval.ToString() != "0"
                            && propval.ToString() != "01/01/0001 00:00:00")
                            return View(SearchFilter(searchAnimal, animalModelCollection));
                    }
                    catch
                    {
                        continue;
                    }

                }

                return View(animalModelCollection);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var animal = _repository.GetAnimalById(id);
                if (animal == null) return NotFound();
                var animalMaped = _mapper.Map<AnimalModel>(animal);
                return View(animalMaped);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Manager/Create
        public ActionResult CreateForm()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalModel animal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedAnimal = _mapper.Map<IAnimal>(animal);
                    _repository.CreateAnimal(mappedAnimal);

                    return RedirectToAction(nameof(Animals));
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }

        // GET: Manager/Edit/5
        [HttpGet]
        [Route("/Manager/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var animal = _repository.GetAnimalById(id);
            if (animal == null) return NotFound();
            var animalMaped = _mapper.Map<AnimalModel>(animal);
            return View(animalMaped);
        }

        // POST: Manager/Edit/5
        [HttpPost("{id}")]
        [Route("/Manager/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnimalModel animal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var DBanimal = _repository.GetAnimalById(id);
                    if (DBanimal == null) return NotFound();
                    var animalMaped = _mapper.Map<AnimalModel>(DBanimal);
                    animal.Id = animalMaped.Id;
                    var animalToDB = _mapper.Map<IAnimal>(animal);
                    _repository.UpdateAnimal(animalToDB);

                    return RedirectToAction(nameof(Animals));
                }
                catch (Exception e)
                {
                    var String = e.Message;
                    return BadRequest();
                }
            }
            return BadRequest();

        }

        public ActionResult Delete(int id)
        {
            try
            {
                var DBanimal = _repository.GetAnimalById(id);
                if (DBanimal == null) return NotFound();
                _repository.DeleteAnimal(DBanimal);
                return RedirectToAction(nameof(Animals));
            }
            catch (Exception e)
            {
                var String = e.Message;
                return BadRequest();
            }
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{

        //    return RedirectToAction("");
        //}

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private List<AnimalModel> SearchFilter(IFormCollection formcollection, IEnumerable<AnimalModel> animalModelCollection)
        {
            var filtered = new List<AnimalModel>();
            for (int i = 0; i < formcollection.Count(); i++)
            {
                var key = formcollection.Keys.ElementAt(i);
                if (String.IsNullOrEmpty(key)) continue;

                switch (key)
                {
                    case nameof(AnimalModel.AnimalNumber):
                        filtered.AddRange(animalModelCollection.Where(x => x.AnimalNumber == formcollection[nameof(x.AnimalNumber)]).ToList());
                        break;
                    case nameof(AnimalModel.Country):
                        filtered.AddRange(animalModelCollection.Where(x => x.Country == formcollection[nameof(x.Country)]).ToList());
                        break;
                    case nameof(AnimalModel.Gender):
                        filtered.AddRange(animalModelCollection.Where(x => x.Gender == formcollection[nameof(x.Gender)]).ToList());
                        break;
                    case nameof(AnimalModel.MotherNumber):
                        filtered.AddRange(animalModelCollection.Where(x => x.MotherNumber == formcollection[nameof(x.MotherNumber)]).ToList());
                        break;
                    case nameof(AnimalModel.FatherNumber):
                        filtered.AddRange(animalModelCollection.Where(x => x.FatherNumber == formcollection[nameof(x.FatherNumber)]).ToList());
                        break;
                    case nameof(AnimalModel.DateOfBirth):
                        filtered.AddRange(animalModelCollection.Where(x => x.DateOfBirth == formcollection[nameof(x.DateOfBirth)]).ToList());
                        break;
                    case nameof(AnimalModel.HerdNumber):
                        filtered.AddRange(animalModelCollection.Where(x => x.HerdNumber == formcollection[nameof(x.HerdNumber)]).ToList());
                        break;
                    case nameof(AnimalModel.PlaceOfBirth):
                        filtered.AddRange(animalModelCollection.Where(x => x.PlaceOfBirth == formcollection[nameof(x.PlaceOfBirth)]).ToList());
                        break;
                    case nameof(AnimalModel.PassportSerial):
                        filtered.AddRange(animalModelCollection.Where(x => x.PassportSerial == formcollection[nameof(x.PassportSerial)]).ToList());
                        break;
                    case nameof(AnimalModel.PassportDate):
                        filtered.AddRange(animalModelCollection.Where(x => x.PassportDate == formcollection[nameof(x.PassportDate)]).ToList());
                        break;
                }

            }
            return filtered;
        }
        private List<AnimalModel> SearchFilter(AnimalModel animal, IEnumerable<AnimalModel> animalModelCollection)
        {
            var filtered = animalModelCollection.Where(
                a =>
                {
                    var passed = false;
                    try
                    {
                        if (animal.AnimalNumber != null) passed = a.AnimalNumber.Contains(animal.AnimalNumber);
                        else if (animal.Country != null) passed = a.Country.Contains(animal.Country);
                        else if (animal.Gender != null) passed = a.Gender.Contains(animal.Gender);
                        else if (animal.DateOfBirth != null && a.DateOfBirth == animal.DateOfBirth) passed = true;
                        else if (animal.PassportDate != null && a.PassportDate == animal.PassportDate) passed = true;
                        else if (animal.MotherNumber != null) passed = a.MotherNumber.Contains(animal.MotherNumber);
                        else if (animal.FatherNumber != null) passed = a.FatherNumber.Contains(animal.FatherNumber);
                        else if (animal.HerdNumber != null) passed = a.HerdNumber.Contains(animal.HerdNumber);
                        else if (animal.PlaceOfBirth != null) passed = a.PlaceOfBirth.Contains(animal.PlaceOfBirth);
                        else if (animal.PassportSerial != null) passed = a.PassportSerial.Contains(animal.PassportSerial);
                    }
                    catch
                    {
                        return false;
                    }
                    return passed;
                }).ToList();
            return filtered;
        }
    }
}
