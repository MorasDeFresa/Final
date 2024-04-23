using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Dto
{
    public class HistoryClientVisitDto
    {
        public required int IdClient { get; set; }
        [ForeignKey("IdClient")]
        // public Client Client { get; set; }
        public int IdEvent { get; set; }
        [ForeignKey("IdEvent")]
        // public Event Event { get; set; }
        public required TimeOnly DateJoin { get; set; }
        public required TimeOnly DateOut { get; set; }
    }
}