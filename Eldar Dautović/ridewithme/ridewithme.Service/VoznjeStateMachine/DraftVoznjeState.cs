using Azure.Core;
using EasyNetQ;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ridewithme.Model.Exceptions;
using ridewithme.Model.Messages;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.VoznjeStateMachine
{
    public class DraftVoznjeState : BaseVoznjeState
    {
        private readonly IEmailService _emailService;
        public DraftVoznjeState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider, IEmailService emailService) : base(dbContext, mapper, serviceProvider)
        {
            _emailService = emailService;
        }

        public override Model.Models.Voznje Update(int id, VoznjeUpdateRequest request)
        {
            var set = Context.Set<Database.Voznje>();

            var entity = set.Find(id);


            if (entity == null)
            {
                throw new UserException("Voznja sa tim ID-om ne postoji.");
            }

            if (Context.Korisnicis.FirstOrDefault(x => x.Id == request.VozacId) == null)
            {
                throw new UserException("Korisnik sa tim ID-om ne postoji.");
            }

            if(request.GradOdId != null && Context.Gradovi.Find(request.GradOdId) == null)
            {
                throw new UserException("GradOd ne postoji.");
            }

            if (request.GradDoId != null && Context.Gradovi.Find(request.GradDoId) == null)
            {
                throw new UserException("GradDo ne postoji.");
            }

            if (request.GradDoId != null && request.GradOdId != null && request.GradOdId == request.GradDoId)
            {
                throw new UserException("Grad polaska ne moze biti jednak Gradu dolaska.");
            }

            if(request.Cijena != null && request.Cijena <= 0)
            {
                throw new UserException("Cijena ne moze biti manja ili jednaka 0.");
            }

            if(request.DatumVrijemePocetka != null && request.DatumVrijemePocetka < DateTime.Now)
            {
                throw new UserException("Datum vrijeme pocetka ne moze biti manje od danasnjeg datuma.");
            }

            Mapper.Config.Default.IgnoreNullValues(true);

            Mapper.Map(request, entity);

            Context.SaveChanges();

            Mapper.Config.Default.IgnoreNullValues(false);

            return Mapper.Map<Model.Models.Voznje>(entity);
        }

        public override Model.Models.Voznje Activate(int id)
        {
            var set = Context.Set<Database.Voznje>().Include(x => x.Vozac).Include(x => x.GradDo).Include(x => x.GradOd);

            var entity = set.FirstOrDefault(x => x.Id == id);

            entity.StateMachine = "active";

            var mappedEntity = Mapper.Map<Model.Models.Voznje>(entity);

            Model.Messages.VoznjeActivated notifikacija = new Model.Messages.VoznjeActivated
            {
                Voznja = mappedEntity,
                email = entity.Vozac.Email
            };

            _emailService.SendingObject(notifikacija);

            Context.SaveChanges();

            return mappedEntity;
        }

        public override Model.Models.Voznje Hide(int id)
        {
            var set = Context.Set<Database.Voznje>();

            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Voznje>(entity);
        }

        public override Model.Models.Voznje Delete(int id)
        {
            var set = Context.Set<Database.Voznje>();

            var entity = set.Find(id);

            set.Remove(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Voznje>(entity);
        }

        public override List<string> AllowedActions(Database.Voznje entity)
        {
            return new List<string>() { nameof(Activate), nameof(Hide), nameof(Update) };
        }
    }
}
