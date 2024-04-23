using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class StatusWorker
    {
        [Key] public int IdStatusWorker { get; set; }
        public required string NameStatus { get; set; }
    }
}