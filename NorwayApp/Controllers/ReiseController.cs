using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NorwayApp.DAL;
using NorwayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorwayApp.Controllers
{
    [Route("[controller]/[action]")]
    public class ReiseController : ControllerBase
    {
        private readonly IReiseRepository _db;

        private ILogger<ReiseController> _log;

        public ReiseController(IReiseRepository db, ILogger<ReiseController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> HentAlleStasjoner()
        {
            List<Stasjoner> alleStasjoner = await _db.HentAlleStasjoner();
            return Ok(alleStasjoner);
        }
        public async Task<ActionResult> FinnStasjoner(String sok)
        {
            List < Stasjoner > funnetStasjoner = await _db.FinnStasjoner(sok);
            return Ok(funnetStasjoner);
        }
        public async Task<ActionResult> VisAvganger(Avgang finnAvgang)
        {
            //if (ModelState.IsValid)
            //{
                List<Avgang> avganger = await _db.VisAvganger(finnAvgang);
                if (avganger == null)
                {
                    _log.LogInformation("Fant ingen avganger");
                    return NotFound("Fant ingen avganger");
                }
                else
                {
                    return Ok(avganger);
                }

            //}
            //_log.LogInformation("Feil i inputvalidering");
            //return BadRequest("Feil i inputvalidering");
        }

    }
}
