using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class Client
    {
        [Key] public int IdClient { get; set; }
        public required int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public required string EmailClient { get; set; }
        public required string PasswordClient { get; set; }
    }
}