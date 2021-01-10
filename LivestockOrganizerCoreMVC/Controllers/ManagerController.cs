using System;
using System.Collections.Generic;
using AutoMapper;
using LivestockOrganizerCoreMVC.Models;
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

        // GET: ManagerController
        public ActionResult Animals()
        {
            ViewBag.Message = "Short herd summary";
            var animalcollection = _repository.GetAllAnimals();

            var animalModelCollection = _mapper.Map<IEnumerable<AnimalModel>>(animalcollection);
            return View(animalModelCollection);
        }

        // GET: ManagerController/AnimalTable/5
        [HttpGet("{id}")]
        [Route("Manager/Details/{id}")]
        public ActionResult Details(int id)
        {
            var animal = _repository.GetAnimalById(id);
            if (animal == null) return NotFound();
            var animalMaped = _mapper.Map<AnimalModel>(animal);
            return View(animalMaped);
        }

        // GET: ManagerController/Create
        public ActionResult CreateForm()
        {

            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var a = new AnimalModel();
                a.AnimalNumber = collection["AnimalNumber"];
                a.Country = collection["Country"];
                a.Gender = collection["Gender"];
                a.MotherNumber = collection["MotherNumber"];
                a.FatherNumber = collection["FatherNumber"];
                a.DateOfBirth = DateTime.Parse(collection["DateOfBirth"]).Date;
                a.HerdNumber = collection["HerdNumber"];
                a.PlaceOfBirth = collection["PlaceOfBirth"];
                a.PassportSerial = collection["PassportSerial"];
                a.PassportDate = DateTime.Parse(collection["PassportDate"]).Date;

                _repository.CreateAnimal(a);

                return RedirectToAction(nameof(Animals));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

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
    }
}
