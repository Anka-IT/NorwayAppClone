using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorwayApp.Models
{
    public class Stasjon
    {
        [Key]
        public int SId { get; set; }
        public string Navn { get; set; }
    }

    public class ReiseContext : DbContext
    {
        public ReiseContext(DbContextOptions<ReiseContext> options)
                   : base(options)
        {
            // denne brukes for å opprette databasen fysisk dersom den ikke er opprettet
            // dette er uavhenig av initiering av databasen (seeding)
            // når man endrer på strukturen på KundeContxt her er det fornuftlig å slette denne fysisk før nye kjøringer
            Database.EnsureCreated();
        }

        public DbSet<Stasjon> Stasjoner { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
