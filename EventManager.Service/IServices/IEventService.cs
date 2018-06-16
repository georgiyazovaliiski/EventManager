using EventManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Service.IServices
{
    // operations you want to expose
    public interface IEventService
    {
        IEnumerable<Event> GetEvents();
        Event GetEvent(int id);
        void CreateEvent(Event Event);
        void EditEvent(Event Event);
        void DeleteEvent(int id);
        void SaveEvent();
    }
}
