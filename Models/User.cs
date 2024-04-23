using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class User
    {
        [Key] public int IdUser { get; set; }
        public required string NameUser { get; set; }
        public required string SurnameUser { get; set; }
        public required string DocumentNumber { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required int IdTypeDocument { get; set; }
        [ForeignKey("IdTypeDocument")]
        public TypeDocument TypeDocument { get; set; }
    }
}