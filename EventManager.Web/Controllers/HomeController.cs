using AutoMapper;
using EventManager.Model;
using EventManager.Service;
using EventManager.Service.IServices;
using EventManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService eventService;

        public HomeController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Event> events = this.eventService.GetEvents().ToList();
            List<EventViewModel> eventViewModels = Mapper.Map<List<Event>, List<EventViewModel>>(events);
            return View(eventViewModels);
        }

        public ActionResult DeleteEvent(int Id)
        {
            //Can be surrounded by try{} catch(){} clause for fool-prove environment
            eventService.DeleteEvent(Id);
            eventService.SaveEvent();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEvent(int Id)
        {
            Event eventToUpdate = eventService.GetEvent(Id);
            EventViewModel eventToPreview = Mapper.Map<Event,EventViewModel>(eventToUpdate);
            return View(eventToPreview);
        }

        [HttpPost]
        public ActionResult EditEvent(EventFormViewModel Event)
        {
            if (Event.EndDate == DateTime.MinValue)
            Event.EndDate = Event.PreviousEndDate;            
            if (Event.StartDate == DateTime.MinValue)
                Event.StartDate = Event.PreviousStartDate;
            Event updatingEvent = Mapper.Map<EventFormViewModel, Event>(Event);
            eventService.EditEvent(updatingEvent);
            eventService.SaveEvent();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(EventFormViewModel Event)
        {
            Event addingEvent = Mapper.Map<EventFormViewModel, Event>(Event);
            eventService.CreateEvent(addingEvent);
            eventService.SaveEvent();
            return View(Event);
        }
    }
}