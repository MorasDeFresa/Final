using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NightClub.Dto;
using NightClub.Models;


namespace Nightclub.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<HistoryClientVisit, HistoryClientVisitDto>();
            CreateMap<SchedulesWorker, SchedulesWorkerDto>();
            CreateMap<TypesWorker, TypesWorkerDto>();
            CreateMap<Worker, WorkerDto>();

        }
    }
}