using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class Worker
    {
        [Key] public int IdWorker { get; set; }
        public required int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public int IdHealthcareProviders { get; set; }
        [ForeignKey("IdHealthcareProviders")]
        public HealthcareProvider HealthcareProvider { get; set; }
        public int IdTypesWorker { get; set; }
        [ForeignKey("IdTypesWorker")]
        public TypesWorker TypesWorker { get; set; }
        public int IdStatusWorker { get; set; }
        [ForeignKey("IdStatusWorker")]
        public StatusWorker StatusWorker { get; set; }
    }
}