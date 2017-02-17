using System;
using System.Linq;
using System.Web.Mvc;
using PartyInvites.Domain.Abstract;
using PartyInvites.Domain.Entities;
using PartyInvites.WebUI.Models;

namespace PartyInvites.WebUI.Controllers {
    public class HomeController : Controller {
        private readonly IRepository<GuestResponse> repo;
        public int PageSize = 4;

        public HomeController(IRepository<GuestResponse> repoParam) {
            repo = repoParam;
        }

        public ViewResult Responses(int page = 1) {
            var model = new GuestResponseListViewModel {
                GuestResponses = repo.GetAllResponses()
                    .OrderBy(p => p.GuestResponsesID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repo.GetAllResponses().Count()
                }
            };
            return View(model);
        }

        public PartialViewResult Widget() {
            return PartialView("Widget");
        }


        // GET: Home
        public ViewResult Index() {
            ViewBag.Responses = repo.GetAllResponses().Count();
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Goedemorgen!" : "Goedemiddag!";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm() {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse) {
            if (ModelState.IsValid)
                return View(repo.AddResponse(guestResponse) ? "Thanks" : "Edit", guestResponse);
            return View();
        }

        //Edit form
        [HttpPost]
        public ViewResult Edit(GuestResponse guestResponse) {
            if (ModelState.IsValid) {
                repo.RemoveResponse(guestResponse);
                repo.AddResponse(guestResponse);
                return View("Thanks");
            }
            return View();
        }
    }
}