using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class HealthcareProvider
    {
        [Key] public int IdHealthcareProvider { get; set; }
        public required string NameHealthcareProvider { get; set; }
        public required long PhoneEmergency { get; set; }
    }
}