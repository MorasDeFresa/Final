using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class Ticket
    {
        [Key] public int IdTicket { get; set; }
        public required int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public Client Client { get; set; }
        public required string SerialNumber { get; set; }
    }
}