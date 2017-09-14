using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class EventsViewModels
    {
        public EventsViewModels()
        {
            SportsList = new HashSet<Sports>();
        }
        public int EventId { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Event Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Event End Date")]
        public DateTime EndDate { get; set; }


        public int SportId { get; set; }
        [Display(Name = "Sport Name")]
        public string SportName { get; set; }

        public long UserId { get; set; }
        public IEnumerable<Venues> VenueList { get; set; }
        public int VenueId { get; set; }
        

        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }

        public IEnumerable<Sports> SportsList { get; set; }

        public bool IsActive { get; set; }
        public bool IsFree { get; set; }
        public int TotalTicketAllowed { get; set; }
        public int TotalBoughtTickets { get; set; }
    }

    public class ChallengeEvent
    {

        public int UserChallengeId { get; set; }
        public int EventId { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Event Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Event End Date")]
        public DateTime EndDate { get; set; }

        public long UserId { get; set; }
        public long ToChallengeId { get; set; }
        public IEnumerable<Users> ToChallengeList { get; set; }
        public IEnumerable<ToChallenge> ToSelectedChallengesList { get; set; }
        public long[] SelectedIds { get; set; }
    }


    public class ToChallenge
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}