using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class TypeMoney
    {
        [Key] public int IdTypeMoney { get; set; }
        public required string NameTypeMoney { get; set; }
    }
}