using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ridewithme.Model.Helpers;
using ridewithme.Model.Models;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Services
{
    public class StatistikaService : IStatistikaService
    {
        RidewithmeContext context;

        public StatistikaService(RidewithmeContext dbContext, IMapper mapper)
        {
            context = dbContext;
        }
        public PagedResult<Statistika> GetList()
        {
            PagedResult<Statistika> paged = new PagedResult<Statistika>();

            paged.Count = 1;
            paged.Results = new List<Statistika>()
            {
                new Statistika
                {
                    BrojIskoristenihKupona = context.Kuponi.Count(x => x.BrojIskoristivosti == 0),
                    BrojKreiranihVoznji = context.Voznje.Count(),
                    BrojRegistrovanihKorisnika = context.Korisnicis.Count()
                }
            };

            return paged;
        }

        public UkupnaStatistika GetMonthlyStatistics()
        {
            var voznjePoMjesecu = context.Voznje
             .GroupBy(x => x.DatumKreiranja.Month)
             .Select(g => new { Mjesec = g.Key, BrojVoznji = g.Count() })
             .ToDictionary(x => x.Mjesec, x => x.BrojVoznji);

            var sviMjeseci = Enumerable.Range(1, 12)
                .Select(m => new MjesecnaStatistika
                {
                    Mjesec = m,
                    BrojVoznji = voznjePoMjesecu.ContainsKey(m) ? voznjePoMjesecu[m] : 0
                })
                .ToList();


            var UkupnaStatistika = new UkupnaStatistika()
            {
                MjesecnaStatistika = sviMjeseci,
                Statistika = new Statistika
                {
                    BrojIskoristenihKupona = context.Kuponi.Count(x => x.BrojIskoristivosti == 0),
                    BrojKreiranihVoznji = context.Voznje.Count(),
                    BrojRegistrovanihKorisnika = context.Korisnicis.Count(),
                    BrojVozaca = context.Voznje.Select(x => x.VozacId).Distinct().Count(),
                    BrojZakazanihVoznji = context.Voznje.Where(x => x.StateMachine == "booked").Count()
                }
            };

            return UkupnaStatistika;

        }

        public List<PoslovniIzvjestaj> GetBusinessReport()
        {
            int currentYear = DateTime.Now.Year;

            var reports = new List<PoslovniIzvjestaj>();

            for (int year = currentYear - 2; year <= currentYear; year++)
            {
                var report = new PoslovniIzvjestaj()
                {
                    Godina = year,
                    BrojAdministratora = context.Korisnicis
                        .Include(x => x.KorisniciUloge)
                        .ThenInclude(y => y.Uloga)
                        .Where(z => z.KorisniciUloge.Any(x => x.Uloga.Naziv == "Administrator") && z.DatumKreiranja.Year == year)
                        .Count(),

                    BrojIskoristenihKupona = context.Kuponi
                        .Count(x => x.BrojIskoristivosti == 0 && x.DatumPocetka.Year == year),

                    BrojKorisnika = context.Korisnicis
                        .Include(x => x.KorisniciUloge)
                        .ThenInclude(y => y.Uloga)
                        .Where(z => z.KorisniciUloge.Any(x => x.Uloga.Naziv == "Korisnik") && z.DatumKreiranja.Year == year)
                        .Count(),

                    BrojKreiranihKupona = context.Kuponi
                        .Count(x => x.DatumPocetka.Year == year),

                    BrojVoznji = context.Voznje
                        .Count(x => x.DatumKreiranja.Year == year),

                    PrihodiVozaca = context.Voznje
                        .Where(x => x.DatumKreiranja.Year == year && (x.StateMachine == "booked" || x.StateMachine == "completed"))
                        .Sum(x => x.Cijena)
                };

                reports.Add(report);
            }

            return reports;
        }

    }
}
