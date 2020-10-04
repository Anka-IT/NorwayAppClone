using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorwayApp.Models
{
  



    public class Ruter
    {
        [Key]
        public string RuteNavn { get; set; }
        public virtual Stasjoner Avreisestasjon { get; set; }
        public virtual Stasjoner Ankomststasjon { get; set; }
    }
    public class Avganger
    {
        [Key]
        public int AId { get; set; }
        public virtual Ruter RuteNavn { get; set; }
        public int Ukedag { get; set; }
        public int Time { get; set; }
        public int Minutter { get; set; }

    }

    public class Stasjoner
    {
        [Key]
        public int SId { get; set; }
        public string StasjonsNavn { get; set; }
    }

    public class Holdeplasser
    {
        [Key]
        public int HId { get; set; }
        public virtual Ruter Rute { get; set; }
        public virtual Stasjoner Stasjon { get; set; }
        public int Tid { get; set; }
        public int Distanse { get; set; }
    }


    public class Priser
    {
        [Key]
        public int PId { get; set; }
        public virtual Stasjoner FraStasjon { get; set; }
        public virtual Stasjoner TilStasjon { get; set; }
        public int Voksen { get; set; }
        public int Barn { get; set; }
        public int Smaabarn { get; set; }
        public int Student { get; set; }
        public int Honnor { get; set; }
        public int Vernepliktig { get; set; }
        public int Ledsager { get; set; }
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

        public DbSet<Ruter> Ruter { get; set; }
        public DbSet<Stasjoner> Stasjoner { get; set; }
        public DbSet<Avganger> Avganger { get; set; }
        public DbSet<Priser> Priser { get; set; }
        public DbSet<Holdeplasser> Holdeplasser { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
