using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IspitController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public IspitController(IspitDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("PreuzmiMaterijale/{idProdavnice}")]        
        public async Task<ActionResult> PreuzmiMaterijale(int idProdavnice)
        {
            try
            {
                var rez = await Context.Spojevi.Where(p=>p.Prodavnica.Id==idProdavnice).Include(p=>p.Materijal).Select(p=>new{
                    SpojID=p.Id,
                    Naziv=p.Materijal.Naziv,
                    Boja=p.Materijal.Boja,
                    Tip=p.Materijal.Tip,
                    CenaMaterijala=p.CenaMaterijala
                }).ToListAsync();
                return Ok(rez);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("PreuzmiProdavnice")]        
        public async Task<ActionResult> PreuzmiProdavnice()
        {
            try
            {
                var rez = await Context.Prodavnice.Select(p=>new{
                    Id=p.Id,
                    Naziv=p.Naziv,
                    Prihod=p.Prihod
                }).ToListAsync();
                return Ok(rez);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("NapraviKorisnika/{idProdavnica}/{ime}/{prezime}")]
        public async Task<ActionResult> NapraviKorisnika(int idProdavnica,string ime,string prezime)
        {
            try
            {
                var prod = await Context.Prodavnice.FirstOrDefaultAsync(p=>p.Id==idProdavnica);
                if(prod==null) return BadRequest("Neposotji takva prodavnica");
                var korisnik = new Korisnik{Ime=ime,Prezime=prezime,Prodavnica=prod};
                Context.Korisnici.Add(korisnik);
                await Context.SaveChangesAsync();
                return Ok(korisnik.Id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("KupiKucu/{idProdavnica}/{idKorisnika}/{cena}")]
        public async Task<ActionResult> KupiKucu(int idProdavnica,int idKorisnika,int cena)
        {
            try
            {
                var korisnik = Context.Korisnici.FirstOrDefault(p=>p.Id==idKorisnika);
                var prodavnica = Context.Prodavnice.FirstOrDefault(p=>p.Id==idProdavnica);
                if(korisnik!=null && prodavnica!=null)
                {
                    var kuca = new Kuca{Prodavnica=prodavnica, Cena=cena,Korisnik=korisnik,DatumPorudzbine=System.DateTime.Now};
                    Context.Kuce.Add(kuca);
                    prodavnica.Prihod+=cena;
                    Context.Update(prodavnica);
                    await Context.SaveChangesAsync();
                    return Ok(prodavnica.Prihod);
                }
                else
                {
                    return BadRequest("Niste validni podaci");
                }      
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
