using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class TypeDocument
    {
        [Key] public int IdTypeDocument { get; set; }
        public required string NameTypeDocument { get; set; }
    }
}