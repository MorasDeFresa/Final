using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class SchedulesWorker
    {
        [Key] public int IdSchedule { get; set; }
        public TimeOnly DateStartWork { get; set; }
        public TimeOnly DateEndWork { get; set; }
        public int IdWorker { get; set; }
        [ForeignKey("IdWorker")]
        public Worker Worker { get; set; }
        public int IdEvent { get; set; }
        [ForeignKey("IdEvent")]
        public Event Event { get; set; }
    }
}