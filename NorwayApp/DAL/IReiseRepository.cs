using NorwayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorwayApp.DAL
{
    public interface IReiseRepository
    {
        Task<List<Stasjoner>> HentAlleStasjoner();
        Task<List<Stasjoner>> FinnStasjoner(String sok);
        Task<List<Avgang>> VisAvganger(Avgang finnAvgang);
    }
}
