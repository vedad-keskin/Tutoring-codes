using MapsterMapper;
using ridewithme.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using ridewithme.Service.Interfaces;
using ridewithme.Model.Models;
using ridewithme.Model.Exceptions;

namespace ridewithme.Service.ZalbeStateMachine
{
    public class InitialZalbeState : BaseZalbeState
    {
        ILogger<InitialZalbeState> _logger;
        IEmailService _emailService;
        public InitialZalbeState(Database.RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider, ILogger<InitialZalbeState> logger, IEmailService emailService) : base(dbContext, mapper, serviceProvider)
        {
            _logger = logger;
            _emailService = emailService;
        }


        public override Zalbe Insert(ZalbeInsertRequest request)
        {

            if (Context.Korisnicis.FirstOrDefault(x => x.Id == request.KorisnikId) == null)
            {
                throw new UserException("Korisnik sa tim ID-om ne postoji.");
            }

            var zalbeSet = Context.Set<Database.Zalbe>();

            Mapper.Config.Default.IgnoreNullValues(true);

            var entity = Mapper.Map<Database.Zalbe>(request);

            Mapper.Config.Default.IgnoreNullValues(false);

            entity.StateMachine = "active";

            entity.DatumIzmjene = DateTime.Now;

            entity.DatumKreiranja = DateTime.Now;

            zalbeSet.Add(entity);

            Context.SaveChanges();

            _logger.LogInformation($"[+] Kreirana je nova Zalba ID: {entity.Id} | Korisnik ID: {request.KorisnikId}");
            _logger.LogInformation("[!!!] Saljem e-mailove administratorima o kreiranju.");

            var adminEmails = Context.Korisnicis.Include(x => x.KorisniciUloge).ThenInclude(x => x.Uloga).Where(x => x.KorisniciUloge.Any(x => x.Uloga.Naziv == "Administrator")).Select(x => x.Email).ToList();

            Model.Messages.ZalbaActivated notifikacija = new Model.Messages.ZalbaActivated
            {
                Zalba = Mapper.Map<Zalbe>(entity),
                AdminEmails = adminEmails,
            };

            _emailService.SendingObject(notifikacija);

            return Mapper.Map<Zalbe>(entity);
        }

        public override List<string> AllowedActions(Database.Zalbe entity)
        {
            return new List<string>() { nameof(Insert) };
        }
    }
}
