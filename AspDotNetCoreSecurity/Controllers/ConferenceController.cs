using AspDotNetCoreSecurity.Models;
using AspDotNetCoreSecurity.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreSecurity.Controllers
{
    [RequireHttps]
    public class ConferenceController:Controller
    {
        private readonly ConferenceRepo _repo;

        public ConferenceController(ConferenceRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Organizer - Conference Overview";
            return View(_repo.GetAll());

        }

        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                _repo.Add(model);

            return RedirectToAction("Index");
        }
    }
}
