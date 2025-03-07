using Mapster;
using MapsterMapper;
using ridewithme.Model.Exceptions;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.KuponiStateMachine
{
    public class DraftKuponiState : BaseKuponiState
    {
        public DraftKuponiState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
        }
        public override Model.Models.Kuponi Activate(int id)
        {
            var set = Context.Set<Database.Kuponi>();

            var entity = set.Find(id);

            entity.StateMachine = "active";

            entity.DatumIzmjene = DateTime.Now;

            //var bus = RabbitHutch.CreateBus("host=localhost");

            var mappedEntity = Mapper.Map<Model.Models.Kuponi>(entity);

            //VoznjeActivated message = new VoznjeActivated{ Voznja = mappedEntity };

            //bus.PubSub.Publish(message);

            Context.SaveChanges();

            return mappedEntity;
        }

        public override Model.Models.Kuponi Hide(int id)
        {
            var set = Context.Set<Database.Kuponi>();

            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            entity.DatumIzmjene = DateTime.Now;

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Kuponi>(entity);
        }

        public override Model.Models.Kuponi Update(int id, KuponiUpdateRequest request)
        {
            var set = Context.Set<Database.Kuponi>();

            var entity = set.Find(id);

            if (entity == null)
            {
                throw new UserException("Kupon sa tim ID-om ne postoji.");
            }

            if (request.Kod.ToUpper() != request.Kod)
            {
                throw new UserException("Kod mora da bude napisan velikim slovima, a razmaci sa '-' (npr. TEST-KOD).");
            }

            if (request.Kod.Contains(" "))
            {
                throw new UserException("Kod ne smije sadrzavati razmake.");
            }

            if (request.Popust > 1.0 || request.Popust <= 0)
            {
                throw new UserException("Popust ne moze biti veci od 100% niti manji od 1%.");
            }

            if (request.BrojIskoristivosti <= 0)
            {
                throw new UserException("Broj iskoristivosti koda ne moze biti manji od 1.");
            }

            Mapper.Config.Default.IgnoreNullValues(true);

            Mapper.Map(request, entity);

            entity.DatumIzmjene = DateTime.Now;

            Context.SaveChanges();

            Mapper.Config.Default.IgnoreNullValues(false);

            return Mapper.Map<Model.Models.Kuponi>(entity);
        }

        public override Model.Models.Kuponi Delete(int id)
        {
            var set = Context.Set<Database.Kuponi>();

            var entity = set.Find(id);


            var voznjeKuponi = Context.Voznje.Where(x => x.KuponId == id).ToList();

            foreach (var v in voznjeKuponi)
            {
                v.KuponId = null;
            }

            Context.SaveChanges();
            set.Remove(entity);
            Context.SaveChanges();

            return Mapper.Map<Model.Models.Kuponi>(entity);
        }

        public override List<string> AllowedActions(Database.Kuponi entity)
        {
            return new List<string>() { nameof(Activate), nameof(Hide), nameof(Update), nameof(Delete) };
        }
    }
}
