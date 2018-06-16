using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Model
{
    public class Event
    { 
        private int _id;
        private string _location;
        private string _name;

        private DateTime _startDate;
        private DateTime _endDate;

        public Event()
        {

        }

        [Required]
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        [Required]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [Required]
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }

        [Required]
        public DateTime StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        [Required]
        public DateTime EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }
    }
}
