using MapsterMapper;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;

namespace ridewithme.Service.VoznjeStateMachine
{
    public class InProgressVoznjeState : BaseVoznjeState
    {
        public InProgressVoznjeState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
        }
        public override Model.Models.Voznje Complete(int id, VoznjeCompleteRequest request)
        {
            var set = Context.Set<Database.Voznje>();

            var entity = set.Find(id);

            entity.StateMachine = "completed";
            entity.DatumVrijemeZavrsetka = DateTime.Now;

            var countOfDriversRides = Context.Voznje.Where(x => x.VozacId == entity.VozacId && x.StateMachine == "completed").Count();
            var countOfUsersRides = Context.Voznje.Where(x => x.KlijentId == entity.KlijentId && x.StateMachine == "completed").Count();

            KorisniciDostignuca driverAchievement = null;
            KorisniciDostignuca usersAchievemnt = null;

            switch(countOfDriversRides)
            {
                case 0:
                    driverAchievement = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 1,
                        KorisnikId = entity.VozacId,
                    };
                break;
                case 10:
                    driverAchievement = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 2,
                        KorisnikId = entity.VozacId,
                    };
                break;
                case 50:
                    driverAchievement = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 3,
                        KorisnikId = entity.VozacId,
                    };
                break;
                case 100:
                    driverAchievement = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 4,
                        KorisnikId = entity.VozacId,
                    };
                break;
                case 500:
                    driverAchievement = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 5,
                        KorisnikId = entity.VozacId,
                    };
                break;
                
                case 1000:
                    driverAchievement = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 5,
                        KorisnikId = entity.VozacId,
                    };
                break;
            }

            switch (countOfUsersRides)
            {
                case 0:
                    usersAchievemnt = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 1,
                        KorisnikId = entity.VozacId,
                    };
                    break;
                case 10:
                    usersAchievemnt = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 2,
                        KorisnikId = entity.VozacId,
                    };
                    break;
                case 50:
                    usersAchievemnt = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 3,
                        KorisnikId = entity.VozacId,
                    };
                    break;
                case 100:
                    usersAchievemnt = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 4,
                        KorisnikId = entity.VozacId,
                    };
                    break;
                case 500:
                    usersAchievemnt = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 5,
                        KorisnikId = entity.VozacId,
                    };
                    break;

                case 1000:
                    usersAchievemnt = new KorisniciDostignuca()
                    {
                        DatumKreiranja = DateTime.Now,
                        DostignuceId = 5,
                        KorisnikId = entity.VozacId,
                    };
                    break;
            }

            if(usersAchievemnt != null)
            {
                Context.Add(usersAchievemnt);
            }

            if(driverAchievement != null)
            {
                Context.Add(driverAchievement);
            }

            var mappedEntity = Mapper.Map<Model.Models.Voznje>(entity);

            Context.SaveChanges();

            return mappedEntity;
        }

        public override List<string> AllowedActions(Database.Voznje entity)
        {
            return new List<string>() { nameof(Complete) };
        }
    }
}
