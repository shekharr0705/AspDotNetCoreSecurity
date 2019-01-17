using AspDotNetCoreSecurity.Models;
using AspDotNetCoreSecurity.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreSecurity.Controllers.API
{

    //[EnableCors("AllowLocalHost")] // Recommed way to use cors -- hence give option to apply cors for perticular controller or action
    //[Route("/api/[controller]")]
    //public class ConferenceController : Controller
    //{
    //    private readonly ConferenceRepo _repo;

    //    public ConferenceController(ConferenceRepo repo)
    //    {
    //        _repo = repo;
    //    }

    //    public IActionResult Index()
    //    {
    //        //ViewBag.Title = "Organizer - Conference Overview";
    //        return Ok(_repo.GetAll());

    //    }

    //    //public IActionResult Add()
    //    //{
    //    //    ViewBag.Title = "Organizer - Add Conference";
    //    //    return View(new ConferenceModel());
    //    //}

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Add(ConferenceModel model)
    //    {
    //        _repo.Add(model);

    //        return Ok(model);
    //    }
    //}
}
