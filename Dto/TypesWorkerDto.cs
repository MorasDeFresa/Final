using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Dto
{
    public class TypesWorkerDto
    {
        public int idTypeMoney { get; set; }
        [ForeignKey("idTypeMoney")]
        // public TypeMoney TypeMoney { get; set; }
        public required string NameTypeWorker { get; set; }
        public required float SalaryForHour { get; set; }
    }
}