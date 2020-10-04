using Microsoft.EntityFrameworkCore;
using NorwayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorwayApp.DAL
{
    public class ReiseRepository : IReiseRepository
    {

        private readonly ReiseContext _db;

        public ReiseRepository(ReiseContext db)
        {
            _db = db;
        }
        public async Task<List<Stasjoner>> HentAlleStasjoner()
        {
            try
            {
                List<Stasjoner> alleStasjoner = await _db.Stasjoner.Select(s => new Stasjoner
                {
                    SId = s.SId,
                    StasjonsNavn = s.StasjonsNavn
                }).ToListAsync();
                return alleStasjoner;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Stasjoner>> FinnStasjoner(String sok)
        {
            try
            {
                List<Stasjoner> funnetStasjoner = await _db.Stasjoner.Where(s => s.StasjonsNavn.Contains(sok)).ToListAsync();

                //List<Stasjoner> funnetStasjoner = await _db.Stasjoner.Where(s => EF.Functions.Like(s.StasjonsNavn,sok)).ToListAsync();

                return funnetStasjoner;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Avgang>> VisAvganger(Avgang finnAvgang)
        {
            try
            {
                Stasjoner fraStasjon = _db.Stasjoner.FirstOrDefault(s => s.StasjonsNavn == finnAvgang.fraStasjon);
                Stasjoner tilStasjon = _db.Stasjoner.FirstOrDefault(s => s.StasjonsNavn == finnAvgang.tilStasjon);
                DateTime turDato = DateTime.Parse(finnAvgang.datepickerTur);
                if (!(finnAvgang.datepickerRetur == null))
                {
                    DateTime returDato = DateTime.Parse(finnAvgang.datepickerRetur);
                }

                Holdeplasser fraHoldeplass= _db.Holdeplasser.FirstOrDefault(s => s.Stasjon== fraStasjon);
                Holdeplasser tilHoldeplass = _db.Holdeplasser.FirstOrDefault(s => s.Stasjon == tilStasjon);

                //Finner reisetiden mellom holdeplassene
                int reisetid = Math.Abs(fraHoldeplass.Tid - tilHoldeplass.Tid);
                //Finner distansen mellom holdeplassene
                int reiseDistanse = Math.Abs(fraHoldeplass.Distanse - tilHoldeplass.Distanse);

                List<Priser> kommendeAvganger = await _db.Priser.Where(a => a.FraStasjon == fraStasjon && a.TilStasjon == tilStasjon).ToListAsync();
                List<Avgang> alleAvganger = new List<Avgang>();

                foreach (var avg in kommendeAvganger)
                {
                    var enAvgang = new Avgang
                    {
                        fraStasjon = avg.FraStasjon.StasjonsNavn,
                        tilStasjon = avg.TilStasjon.StasjonsNavn,
                        ruteNavn = fraHoldeplass.Rute.RuteNavn,
                        tid=reisetid,
                        distanse=reiseDistanse,
                        datepickerTur = finnAvgang.datepickerTur,
                        datepickerRetur = finnAvgang.datepickerRetur,
                        voksen = finnAvgang.voksen,
                        barn = finnAvgang.barn,
                        smaabarn = finnAvgang.smaabarn,
                        student = finnAvgang.student,
                        honnor = finnAvgang.honnor,
                        vernepliktig = finnAvgang.vernepliktig,
                        ledsager = finnAvgang.ledsager,
                        prisVoksen = finnAvgang.voksen * avg.Voksen,
                        prisBarn = finnAvgang.barn * avg.Barn,
                        prisSmaabarn = finnAvgang.smaabarn * avg.Smaabarn,
                        prisStudent = finnAvgang.student * avg.Student,
                        prisHonnor = finnAvgang.honnor * avg.Honnor,
                        prisVernepliktig = finnAvgang.vernepliktig * avg.Vernepliktig,
                        prisLedsager = finnAvgang.ledsager * avg.Ledsager
                    };
                    alleAvganger.Add(enAvgang);
                }
                return alleAvganger;
            }
            catch
            {
                return null;
            }
        }
    }
}
