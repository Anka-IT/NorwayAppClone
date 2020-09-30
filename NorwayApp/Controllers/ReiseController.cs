using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorwayApp.Controllers
{

    public class Linjer
    {
        [Key]
        public string LinjeNavn { get; set; }
        public virtual Stasjoner Avreisestasjon { get; set; }
        public virtual Stasjoner Ankomststasjon { get; set; }
    }
    public class Avganger
    {
        public int Id { get; set; }
        public virtual Linjer LinjeNavn { get; set; }
        public int Ukedag { get; set; }
        public int Time { get; set; }
        public int Minutter { get; set; }

    }

    public class Stasjoner
    {
        [Key]
        public int Id { get; set; }
        public string LinjeNavn { get; set; }
        public string StasjonsNavn { get; set; }
        public int Distanse { get; set; }
        public int Tid { get; set; }
        public int Spor { get; set; }
    }

    public class Priser
    {
        public int Id { get; set; }
        public virtual Stasjoner FraStasjon { get; set; }
        public virtual Stasjoner TilStasjon { get; set; }
        public int Voksen { get; set; }
        public int Barn { get; set; }
        public int Student { get; set; }
        public int Ungdom { get; set; }
        public int Honnor { get; set; }
        public int Verneplikt { get; set; }

    }

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=MetWay")
        {
            Database.CreateIfNotExists();

            /*Linjen nedenfor avkommenteres og løsningen kjøres to ganger på rad for å få generert en database med test data.
            Deretter kommenteres den igjen ved senere bruk for å unngå feilmedinger som har dukket opp.*/

            //Database.SetInitializer(new DBinit());
        }

        public DbSet<Linjer> Linjer { get; set; }
        public DbSet<Stasjoner> Stasjoner { get; set; }
        public DbSet<Avganger> Avganger { get; set; }
        public DbSet<Priser> Priser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}
