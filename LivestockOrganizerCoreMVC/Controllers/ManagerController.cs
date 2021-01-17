using System;
using System.Collections.Generic;
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
        public ActionResult Animals()
        {
            try
            {
                ViewBag.Message = "Short herd summary";
                var animalcollection = _repository.GetAllAnimals();

                var animalModelCollection = _mapper.Map<IEnumerable<AnimalModel>>(animalcollection);
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
            catch(Exception e)
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
    }
}
