using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Dto
{
    public class WorkerDto
    {
        public string NameUser { get; set; }
        public string SurnameUser { get; set; }
        public string DocumentNumber { get; set; }
        public int IdTypeDocument { get; set; }
        [ForeignKey("IdTypeDocument")]
        public int IdHealthcareProviders { get; set; }
        [ForeignKey("IdHealthcareProviders")]
        // public HealthcareProvider HealthcareProvider { get; set; }
        public int IdTypesWorker { get; set; }
        [ForeignKey("IdTypesWorker")]
        // public TypesWorker TypesWorker { get; set; }
        public int IdStatusWorker { get; set; }
        [ForeignKey("IdStatusWorker")]
        // public StatusWorker StatusWorker { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}