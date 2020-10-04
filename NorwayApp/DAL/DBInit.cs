using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorwayApp.Models
{
    public class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<ReiseContext>();
                
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var nyStasjon1 = new Stasjoner { StasjonsNavn = "Kongsberg" };
                var nyStasjon2 = new Stasjoner { StasjonsNavn = "Darbu" };
                var nyStasjon3 = new Stasjoner { StasjonsNavn = "Vestfossen" };
                var nyStasjon4 = new Stasjoner { StasjonsNavn = "Hokksund" };
                var nyStasjon5 = new Stasjoner { StasjonsNavn = "Steinberg" };
                var nyStasjon6 = new Stasjoner { StasjonsNavn = "Mjøndalen" };
                var nyStasjon7 = new Stasjoner { StasjonsNavn = "Gulskogen" };
                var nyStasjon8 = new Stasjoner { StasjonsNavn = "Drammen" };
                var nyStasjon9 = new Stasjoner { StasjonsNavn = "Asker" };
                var nyStasjon10 = new Stasjoner { StasjonsNavn = "Sandvika" };
                var nyStasjon11 = new Stasjoner { StasjonsNavn = "Lysaker" };
                var nyStasjon12 = new Stasjoner { StasjonsNavn = "Skøyen" };
                var nyStasjon13 = new Stasjoner { StasjonsNavn = "Nationaltheatret" };
                var nyStasjon14 = new Stasjoner { StasjonsNavn = "Oslo S" };
                var nyStasjon15 = new Stasjoner { StasjonsNavn = "Lillestrøm" };
                var nyStasjon16 = new Stasjoner { StasjonsNavn = "Oslo Lufthavn" };
                var nyStasjon17 = new Stasjoner { StasjonsNavn = "Eidsvoll Verk" };
                var nyStasjon18 = new Stasjoner { StasjonsNavn = "Eidsvoll" };


                var nyRute1 = new Ruter { RuteNavn = "L12", Avreisestasjon = nyStasjon1, Ankomststasjon = nyStasjon18 };
                var nyRute2 = new Ruter { RuteNavn = "L12R", Avreisestasjon = nyStasjon18, Ankomststasjon = nyStasjon1 };


                var nyHoldeplass1 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon1, Tid = 0, Distanse = 0 };
                var nyHoldeplass2 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon2, Tid = 12, Distanse = 16 };
                var nyHoldeplass3 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon3, Tid = 18, Distanse = 24 };
                var nyHoldeplass4 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon4, Tid = 24, Distanse = 32 };
                var nyHoldeplass5 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon5, Tid = 27, Distanse = 36 };
                var nyHoldeplass6 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon6, Tid = 30, Distanse = 40 };
                var nyHoldeplass7 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon7, Tid = 37, Distanse = 49 };
                var nyHoldeplass8 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon8, Tid = 41, Distanse = 54 };
                var nyHoldeplass9 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon9, Tid = 54, Distanse = 72 };
                var nyHoldeplass10 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon10, Tid = 60, Distanse = 80 };
                var nyHoldeplass11 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon11, Tid = 66, Distanse = 88 };
                var nyHoldeplass12 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon12, Tid = 69, Distanse = 92 };
                var nyHoldeplass13 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon13, Tid = 73, Distanse = 97 };
                var nyHoldeplass14 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon14, Tid = 77, Distanse = 102 };
                var nyHoldeplass15 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon15, Tid = 90, Distanse = 120 };
                var nyHoldeplass16 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon16, Tid = 103, Distanse = 137 };
                var nyHoldeplass17 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon17, Tid = 110, Distanse = 146 };
                var nyHoldeplass18 = new Holdeplasser { Rute = nyRute1, Stasjon = nyStasjon18, Tid = 116, Distanse = 155 };
                var nyHoldeplass19 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon1, Tid = 116, Distanse = 155 };
                var nyHoldeplass20 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon2, Tid = 104, Distanse = 138 };
                var nyHoldeplass21 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon3, Tid = 98, Distanse = 130 };
                var nyHoldeplass22 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon4, Tid = 92, Distanse = 122 };
                var nyHoldeplass23 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon5, Tid = 89, Distanse = 118 };
                var nyHoldeplass24 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon6, Tid = 86, Distanse = 114 };
                var nyHoldeplass25 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon7, Tid = 79, Distanse = 105 };
                var nyHoldeplass26 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon8, Tid = 75, Distanse = 100 };
                var nyHoldeplass27 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon9, Tid = 62, Distanse = 82 };
                var nyHoldeplass28 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon10, Tid = 56, Distanse = 74 };
                var nyHoldeplass29 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon11, Tid = 50, Distanse = 66 };
                var nyHoldeplass30 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon12, Tid = 47, Distanse = 62 };
                var nyHoldeplass31 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon13, Tid = 43, Distanse = 57 };
                var nyHoldeplass32 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon14, Tid = 39, Distanse = 52 };
                var nyHoldeplass33 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon15, Tid = 26, Distanse = 34 };
                var nyHoldeplass34 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon16, Tid = 13, Distanse = 17 };
                var nyHoldeplass35 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon17, Tid = 6, Distanse = 8 };
                var nyHoldeplass36 = new Holdeplasser { Rute = nyRute2, Stasjon = nyStasjon18, Tid = 0, Distanse = 0 };
                var Holdeplasser1 = new List<Holdeplasser>();
                var Holdeplasser2 = new List<Holdeplasser>();
                Holdeplasser1.Add(nyHoldeplass1);
                Holdeplasser1.Add(nyHoldeplass2);
                Holdeplasser1.Add(nyHoldeplass3);
                Holdeplasser1.Add(nyHoldeplass4);
                Holdeplasser1.Add(nyHoldeplass5);
                Holdeplasser1.Add(nyHoldeplass6);
                Holdeplasser1.Add(nyHoldeplass7);
                Holdeplasser1.Add(nyHoldeplass8);
                Holdeplasser1.Add(nyHoldeplass9);
                Holdeplasser1.Add(nyHoldeplass10);
                Holdeplasser1.Add(nyHoldeplass11);
                Holdeplasser1.Add(nyHoldeplass12);
                Holdeplasser1.Add(nyHoldeplass13);
                Holdeplasser1.Add(nyHoldeplass14);
                Holdeplasser1.Add(nyHoldeplass15);
                Holdeplasser1.Add(nyHoldeplass16);
                Holdeplasser1.Add(nyHoldeplass17);
                Holdeplasser1.Add(nyHoldeplass18);
                Holdeplasser2.Add(nyHoldeplass19);
                Holdeplasser2.Add(nyHoldeplass20);
                Holdeplasser2.Add(nyHoldeplass21);
                Holdeplasser2.Add(nyHoldeplass22);
                Holdeplasser2.Add(nyHoldeplass23);
                Holdeplasser2.Add(nyHoldeplass24);
                Holdeplasser2.Add(nyHoldeplass25);
                Holdeplasser2.Add(nyHoldeplass26);
                Holdeplasser2.Add(nyHoldeplass27);
                Holdeplasser2.Add(nyHoldeplass28);
                Holdeplasser2.Add(nyHoldeplass29);
                Holdeplasser2.Add(nyHoldeplass30);
                Holdeplasser2.Add(nyHoldeplass31);
                Holdeplasser2.Add(nyHoldeplass32);
                Holdeplasser2.Add(nyHoldeplass33);
                Holdeplasser2.Add(nyHoldeplass34);
                Holdeplasser2.Add(nyHoldeplass35);
                Holdeplasser2.Add(nyHoldeplass36);

                foreach (Holdeplasser stasjonfra in Holdeplasser1)
                {
                    foreach (Holdeplasser stasjontil in Holdeplasser1)
                    {
                        if (stasjonfra.Stasjon != stasjontil.Stasjon)
                        {
                            int prisVoksen = Math.Abs((stasjonfra.Tid - stasjontil.Tid) * 2) + 25;
                            int prisStudent = (int)Math.Round(prisVoksen * 0.75, 0);
                            int prisBarn = (int)Math.Round(prisVoksen * 0.5, 0);
                            int prisSmaabarn = (int)Math.Round(prisVoksen * 0.5, 0);
                            int prisHonnor = (int)Math.Round(prisVoksen * 0.5, 0);
                            int prisVernepliktig = (int)Math.Round(prisVoksen * 0.1, 0);
                            int prisLedsager = (int)Math.Round(prisVoksen * 0.5, 0);
                            var nyPris1 = new Priser { Voksen = prisVoksen, Barn = prisBarn, Smaabarn = prisSmaabarn, Student = prisStudent, Honnor = prisHonnor, Vernepliktig = prisVernepliktig, Ledsager = prisLedsager, FraStasjon = stasjonfra.Stasjon, TilStasjon = stasjontil.Stasjon };
                            context.Priser.Add(nyPris1);
                        }
                    }
                }


                var avganger = new List<Avganger>();
                for (int i = 1; i < 8; i++)
                {
                    int jstart = 4;
                    if (i > 5) { jstart = 5; }

                    for (int j = jstart; j < 23; j++)
                    {
                        var avgang = new Avganger { RuteNavn = nyRute1, Ukedag = i, Time = j, Minutter = 34 };
                        var avgang2 = new Avganger { RuteNavn = nyRute2, Ukedag = i, Time = j + 1, Minutter = 30 };
                        avganger.Add(avgang);
                        avganger.Add(avgang2);
                    }
                }

                context.Stasjoner.Add(nyStasjon1);
                context.Stasjoner.Add(nyStasjon2);
                context.Stasjoner.Add(nyStasjon3);
                context.Stasjoner.Add(nyStasjon4);
                context.Stasjoner.Add(nyStasjon5);
                context.Stasjoner.Add(nyStasjon6);
                context.Stasjoner.Add(nyStasjon7);
                context.Stasjoner.Add(nyStasjon8);
                context.Stasjoner.Add(nyStasjon9);
                context.Stasjoner.Add(nyStasjon10);
                context.Stasjoner.Add(nyStasjon11);
                context.Stasjoner.Add(nyStasjon12);
                context.Stasjoner.Add(nyStasjon13);
                context.Stasjoner.Add(nyStasjon14);
                context.Stasjoner.Add(nyStasjon15);
                context.Stasjoner.Add(nyStasjon16);
                context.Stasjoner.Add(nyStasjon17);
                context.Stasjoner.Add(nyStasjon18);



                context.Holdeplasser.Add(nyHoldeplass1);
                context.Holdeplasser.Add(nyHoldeplass2);
                context.Holdeplasser.Add(nyHoldeplass3);
                context.Holdeplasser.Add(nyHoldeplass4);
                context.Holdeplasser.Add(nyHoldeplass5);
                context.Holdeplasser.Add(nyHoldeplass6);
                context.Holdeplasser.Add(nyHoldeplass7);
                context.Holdeplasser.Add(nyHoldeplass8);
                context.Holdeplasser.Add(nyHoldeplass9);
                context.Holdeplasser.Add(nyHoldeplass10);
                context.Holdeplasser.Add(nyHoldeplass11);
                context.Holdeplasser.Add(nyHoldeplass12);
                context.Holdeplasser.Add(nyHoldeplass13);
                context.Holdeplasser.Add(nyHoldeplass14);
                context.Holdeplasser.Add(nyHoldeplass15);
                context.Holdeplasser.Add(nyHoldeplass16);
                context.Holdeplasser.Add(nyHoldeplass17);
                context.Holdeplasser.Add(nyHoldeplass18);
                context.Holdeplasser.Add(nyHoldeplass19);
                context.Holdeplasser.Add(nyHoldeplass20);
                context.Holdeplasser.Add(nyHoldeplass21);
                context.Holdeplasser.Add(nyHoldeplass22);
                context.Holdeplasser.Add(nyHoldeplass23);
                context.Holdeplasser.Add(nyHoldeplass24);
                context.Holdeplasser.Add(nyHoldeplass25);
                context.Holdeplasser.Add(nyHoldeplass26);
                context.Holdeplasser.Add(nyHoldeplass27);
                context.Holdeplasser.Add(nyHoldeplass28);
                context.Holdeplasser.Add(nyHoldeplass29);
                context.Holdeplasser.Add(nyHoldeplass30);
                context.Holdeplasser.Add(nyHoldeplass31);
                context.Holdeplasser.Add(nyHoldeplass32);
                context.Holdeplasser.Add(nyHoldeplass33);
                context.Holdeplasser.Add(nyHoldeplass34);
                context.Holdeplasser.Add(nyHoldeplass35);
                context.Holdeplasser.Add(nyHoldeplass36);

                context.Ruter.Add(nyRute1);
                context.Ruter.Add(nyRute2);
                foreach (Avganger avgang in avganger)
                {
                    context.Avganger.Add(avgang);
                }
                context.SaveChanges();
            }
        }
    }
}
