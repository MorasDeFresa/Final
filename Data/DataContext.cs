using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NightClub.Models;

namespace Nightclub.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<HealthcareProvider> HealthcareProviders { get; set; }
        public DbSet<HistoryClientVisit> HistoryClientVisitss { get; set; }
        public DbSet<SchedulesWorker> SchedulesWorkers { get; set; }
        public DbSet<StatusWorker> StatusWorkers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TypeDocument> TypeDocuments { get; set; }
        public DbSet<TypeMoney> TypeMoneys { get; set; }
        public DbSet<TypesWorker> TypesWorkers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}