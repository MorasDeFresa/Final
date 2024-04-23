using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class Event
    {
        [Key] public int IdEvent { get; set; }
        public required string NameEvent { get; set; }
        public required DateOnly DateEvent { get; set; }
        public required int MaximumClientCapacity { get; set; }
    }
}