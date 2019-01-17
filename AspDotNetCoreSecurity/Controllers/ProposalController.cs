using AspDotNetCoreSecurity.Models;
using AspDotNetCoreSecurity.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreSecurity.Controllers
{
    public class ProposalController : Controller
    {

        private readonly ConferenceRepo conferenceRepo;
        private readonly ProposalRepo proposalRepo;
        public readonly IDataProtector _dataProtector;
        public ProposalController(ConferenceRepo conferenceRepo, ProposalRepo proposalRepo,IDataProtectionProvider dataProtectionProvider,PurposeStringConstants purposeStringConstants)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(purposeStringConstants.ConferenceIdQueryString);
            this.conferenceRepo = conferenceRepo;
            this.proposalRepo = proposalRepo;
        }

        public IActionResult Index(string conferenceId)
        {
            var decryptedConferenceId = _dataProtector.Unprotect(conferenceId);
            var conference = conferenceRepo.GetById(int.Parse(decryptedConferenceId));
            ViewBag.Title = $"Speaker - Proposals For Conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = decryptedConferenceId;

            return View(proposalRepo.GetAllForConference(int.Parse(decryptedConferenceId)));
        }

        public IActionResult AddProposal(int conferenceId)
        {
            ViewBag.Title = "Speaker - Add Proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }

        [HttpPost]
        public IActionResult AddProposal(ProposalModel proposal)
        {
            if (ModelState.IsValid)
                proposalRepo.Add(proposal);
            return RedirectToAction("Index", new { conferenceId = _dataProtector.Protect(proposal.ConferenceId.ToString()) });
        }

        public IActionResult Approve(int proposalId)
        {
            var proposal = proposalRepo.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = _dataProtector.Protect(proposal.ConferenceId.ToString()) });
        }
    }
}
