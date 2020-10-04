using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorwayApp.Models
{

    public class Avgang
    {
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2-30}$")]
        public String fraStasjon { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2-30}$")]
        public String tilStasjon { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZæøåÆØÅ. \-]{2-30}$")]
        public String ruteNavn { get; set; }
        public String datepickerTur { get; set; }
        public String datepickerRetur { get; set; }
        [RegularExpression(@"^[0-9]{4}$")]
        public int distanse { get; set; }
        [RegularExpression(@"^[0-9]{4}$")]
        public int tid { get; set; }
        //Antall reisende i hver kategori
        [RegularExpression(@"^[0-9]{1}$")]
        public int voksen { get; set; }
        [RegularExpression(@"^[0-9]{1}$")]
        public int barn { get; set; }
        [RegularExpression(@"^[0-9]{1}$")]
        public int smaabarn { get; set; }
        [RegularExpression(@"^[0-9]{1}$")]
        public int student { get; set; }
        [RegularExpression(@"^[0-9]{1}$")]
        public int honnor { get; set; }
        [RegularExpression(@"^[0-9]{1}$")]
        public int vernepliktig { get; set; }
        [RegularExpression(@"^[0-9]{1}$")]
        public int ledsager { get; set; }

        //Pris for reisende i hver kategori
        [RegularExpression(@"^[0-9]{0-6}$")]
        public int prisVoksen { get; set; }
        [RegularExpression(@"^[0-9]{0-6}$")]
        public int prisBarn { get; set; }
        [RegularExpression(@"^[0-9]{0-6}$")]
        public int prisSmaabarn { get; set; }
        [RegularExpression(@"^[0-9]{0-6}$")]
        public int prisStudent { get; set; }
        [RegularExpression(@"^[0-9]{0-6}$")]
        public int prisHonnor { get; set; }
        [RegularExpression(@"^[0-9]{0-6}$")]
        public int prisVernepliktig { get; set; }
        [RegularExpression(@"^[0-9]{0-6}$")]
        public int prisLedsager { get; set; }

    }

    public class Rute
    {
        public string ruteNavn { get; set; }
        public string avreisestasjon { get; set; }
        public string ankomststasjon { get; set; }
        public int tid { get; set; }
        public int lengde { get; set; }
    }
    public class Pris
    {
        public int pid { get; set; }
        public string ruteNavn { get; set; }
        public string fraStasjon { get; set; }
        public string tilStasjon { get; set; }
        public int voksen { get; set; }
        public int barn { get; set; }
        public int smaabarn { get; set; }
        public int student { get; set; }
        public int honnor { get; set; }
        public int vernepliktig { get; set; }
        public int ledsager { get; set; }

    }
    public class Stasjon
    {
        public int sid { get; set; }
        public string ruteNavn { get; set; }
        public string stasjonsNavn { get; set; }
        public int distanse { get; set; }
        public int tid { get; set; }
        }
}
