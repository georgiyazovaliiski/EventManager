using EventManager.Data.Infrastructure;
using EventManager.Data.Repositories;
using EventManager.Model;
using EventManager.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventsRepository;
        private readonly IUnitOfWork unitOfWork;

        public EventService(IEventRepository EventsRepository, IUnitOfWork unitOfWork)
        {
            this.eventsRepository = EventsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IEventService Members

        public IEnumerable<Event> GetEvents()
        {
            var Events = eventsRepository.GetAll();
            return Events;
        }

        public Event GetEvent(int id)
        {
            var Event = eventsRepository.GetById(id);
            return Event;
        }

        public void CreateEvent(Event Event)
        {
            eventsRepository.Add(Event);
        }

        public void DeleteEvent(int Id)
        {
            var Event = eventsRepository.GetById(Id);
            eventsRepository.Delete(Event);
        }

        public void EditEvent(Event Event)
        {
            eventsRepository.Update(Event);
        }

        public void SaveEvent()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
