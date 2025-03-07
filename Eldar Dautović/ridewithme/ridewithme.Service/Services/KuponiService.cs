using MapsterMapper;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using ridewithme.Service.KuponiStateMachine;
using System.Linq.Dynamic.Core;


namespace ridewithme.Service.Services
{
    public class KuponiService : BaseCRUDService<Model.Models.Kuponi, KuponiSearchObject, Database.Kuponi, KuponiInsertRequest, KuponiUpdateRequest>, IKuponiService
    {
        public BaseKuponiState BaseKuponiState { get; set; }
        public KuponiService(RidewithmeContext dbContext, IMapper mapper, BaseKuponiState baseKuponiState) : base(dbContext, mapper)
        {
            BaseKuponiState = baseKuponiState;
        }

        public override Model.Models.Kuponi Insert(KuponiInsertRequest request)
        {
            var state = BaseKuponiState.CreateState("initial");
            return state.Insert(request);
        }

        public override Model.Models.Kuponi Update(int id, KuponiUpdateRequest request)
        {
            var entity = GetById(id);
            var state = BaseKuponiState.CreateState(entity.StateMachine);

            return state.Update(id, request);
        }

        public Model.Models.Kuponi Delete(int id)
        {
            var entity = GetById(id);
            var state = BaseKuponiState.CreateState(entity.StateMachine);

            return state.Delete(id);
        }

        public ProvjerenKupon Check(string kod)
        {
            var kupon = Context.Kuponi.FirstOrDefault(x => x.Kod == kod);

            var ispravnostKupona = new ProvjerenKupon();

            if (kupon == null || kupon.StateMachine != "active" || kupon.BrojIskoristivosti == 0)
            {
                ispravnostKupona.ispravanKupon = false;
                return ispravnostKupona;
            }

            ispravnostKupona.ispravanKupon = true;
            ispravnostKupona.Kupon = Mapper.Map<Model.Models.Kuponi>(kupon);

            return ispravnostKupona;
        }

        public override IQueryable<Database.Kuponi> AddFilter(KuponiSearchObject searchObject, IQueryable<Database.Kuponi> query)
        {
            if (searchObject.KuponId.HasValue)
            {
                query = query.Where(x => x.Id == searchObject.KuponId.Value);
            }

            if (searchObject.PopustGTE.HasValue)
            {
                query = query.Where(x => x.Popust >= searchObject.PopustGTE.Value / 100);
            }

            if (searchObject.BrojIskoristivostiGTE.HasValue)
            {
                query = query.Where(x => x.BrojIskoristivosti >= searchObject.BrojIskoristivostiGTE.Value);
            }

            if (searchObject.DatumPocetka.HasValue)
            {
                query = query.Where(x => x.DatumPocetka == searchObject.DatumPocetka.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchObject.KodGTE))
            {
                query = query.Where(x => x.Kod.Contains(searchObject.KodGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject.NazivGTE))
            {
                query = query.Where(x => x.Naziv.Contains(searchObject.NazivGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.OrderBy))
            {
                var items = searchObject.OrderBy.Split(' ');
                if (items.Length > 2 || items.Length == 0)
                {
                    throw new ApplicationException("Mozete sortirati samo po dva polja.");
                }
                if (items.Length == 1)
                {
                    query = query.OrderBy("@0", searchObject.OrderBy);
                }
                else
                {
                    query = query.OrderBy(string.Format("{0} {1}", items[0], items[1]));
                }

            }

            if (!string.IsNullOrWhiteSpace(searchObject?.Status))
            {
                query = query.Where(x => x.StateMachine == searchObject.Status);
            }


            return query;
        }

        public Model.Models.Kuponi Activate(int id)
        {
            var entity = GetById(id);
            var state = BaseKuponiState.CreateState(entity.StateMachine);

            return state.Activate(id);
        }
        public Model.Models.Kuponi Hide(int id)
        {
            var entity = GetById(id);
            var state = BaseKuponiState.CreateState(entity.StateMachine);

            return state.Hide(id);
        }

        public Model.Models.Kuponi Edit(int id)
        {
            var entity = GetById(id);
            var state = BaseKuponiState.CreateState(entity.StateMachine);

            return state.Edit(id);
        }

        public List<string> AllowedActions(int id)
        {
            if (id <= 0)
            {
                var state = BaseKuponiState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = Context.Kuponi.Find(id);
                var state = BaseKuponiState.CreateState(entity.StateMachine);
                return state.AllowedActions(entity);
            }
        }

    }
}
