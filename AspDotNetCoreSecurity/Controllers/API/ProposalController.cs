using AspDotNetCoreSecurity.Models;
using AspDotNetCoreSecurity.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreSecurity.Controllers.API
{
   // [Route("/api/[controller]")]
    //public class ProposalController : Controller
    //{

    //    private readonly ConferenceRepo conferenceRepo;
    //    private readonly ProposalRepo proposalRepo;

    //    public ProposalController(ConferenceRepo conferenceRepo, ProposalRepo proposalRepo)
    //    {
    //        this.conferenceRepo = conferenceRepo;
    //        this.proposalRepo = proposalRepo;
    //    }

    //    public IActionResult Index(int conferenceId)
    //    {
    //        var conference = conferenceRepo.GetById(conferenceId);
    //        ViewBag.Title = $"Speaker - Proposals For Conference {conference.Name} {conference.Location}";
    //        ViewBag.ConferenceId = conferenceId;

    //        return Ok(proposalRepo.GetAllForConference(conferenceId));
    //    }

    //    //public IActionResult AddProposal(int conferenceId)
    //    //{
    //    //    ViewBag.Title = "Speaker - Add Proposal";
    //    //    return Ok(new ProposalModel { ConferenceId = conferenceId });
    //    //}

    //    [HttpPost]
    //    public IActionResult AddProposal(ProposalModel proposal)
    //    {
    //        //if (ModelState.IsValid)
    //        //    proposalRepo.Add(proposal);
    //        proposalRepo.Add(proposal);
    //        return Ok(new { conferenceId = proposal.ConferenceId });
    //    }

    //    public IActionResult Approve(int proposalId)
    //    {
    //        var proposal = proposalRepo.Approve(proposalId);
    //        return Ok(new { conferenceId = proposal.ConferenceId });
    //    }
    //}
}
