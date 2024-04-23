using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Dto
{
    public class ClientDto
    {
        // public TypeDocument TypeDocument { get; set; }
        public string NameUser { get; set; }
        public string SurnameUser { get; set; }
        public string DocumentNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int IdTypeDocument { get; set; }
        [ForeignKey("IdTypeDocument")]
        // public required int IdUser { get; set; }
        // [ForeignKey("IdUser")]
        // public User User { get; set; }
        public string EmailClient { get; set; }
        public string PasswordClient { get; set; }
    }
}