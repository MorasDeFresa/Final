using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Dto
{
    public class TicketDto
    {
        public required int IdClient { get; set; }
        [ForeignKey("IdClient")]
        // public Client Client { get; set; }
        public required string SerialNumber { get; set; }
    }
}