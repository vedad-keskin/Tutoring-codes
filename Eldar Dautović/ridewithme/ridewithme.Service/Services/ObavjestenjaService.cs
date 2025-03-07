using MapsterMapper;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using ridewithme.Service.ObavjestenjaStateMachine;
using System.Linq.Dynamic.Core;

namespace ridewithme.Service.Services
{
    public class ObavjestenjaService : BaseCRUDService<Model.Models.Obavjestenja, ObavjestenjaSearchObject, Database.Obavjestenja, ObavjestenjaInsertRequest, ObavjestenjaUpdateRequest>, IObavjestenjaService
    {
        public BaseObavjestenjaState BaseObavjestenjaState { get; set; }

        public ObavjestenjaService(RidewithmeContext dbContext, IMapper mapper, BaseObavjestenjaState baseObavjestenjaState) : base(dbContext, mapper)
        {
            BaseObavjestenjaState = baseObavjestenjaState;
        }

        public override IQueryable<Database.Obavjestenja> AddFilter(ObavjestenjaSearchObject searchObject, IQueryable<Database.Obavjestenja> query)
        {
            if (searchObject.IsCompletedIncluded.HasValue && searchObject.IsCompletedIncluded == false)
            {
                query = query.Where(x => x.DatumZavrsetka > DateTime.Now || x.StateMachine == "active");
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

            if (searchObject.DatumOdGTE.HasValue)
            {
                query = query.Where(x => x.DatumZavrsetka >= searchObject.DatumOdGTE.Value);
            }

            if (searchObject.DatumDoGTE.HasValue)
            {
                query = query.Where(x => x.DatumZavrsetka <= searchObject.DatumDoGTE.Value);
            }

            return query;
        }

        public override Model.Models.Obavjestenja Insert(ObavjestenjaInsertRequest request)
        {
            var state = BaseObavjestenjaState.CreateState("initial");
            return state.Insert(request);
        }

        public override Model.Models.Obavjestenja Update(int id, ObavjestenjaUpdateRequest request)
        {
            var entity = GetById(id);
            var state = BaseObavjestenjaState.CreateState(entity.StateMachine);

            return state.Update(id, request);
        }
        public List<string> AllowedActions(int id)
        {
            if (id <= 0)
            {
                var state = BaseObavjestenjaState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = Context.Obavjestenja.Find(id);
                var state = BaseObavjestenjaState.CreateState(entity.StateMachine);
                return state.AllowedActions(entity);
            }
        }

        public Model.Models.Obavjestenja Activate(int id)
        {
            var entity = GetById(id);
            var state = BaseObavjestenjaState.CreateState(entity.StateMachine);

            return state.Activate(id);
        }

        public Model.Models.Obavjestenja Complete(int id)
        {
            var entity = GetById(id);
            var state = BaseObavjestenjaState.CreateState(entity.StateMachine);

            return state.Complete(id);
        }

        public Model.Models.Obavjestenja Hide(int id)
        {
            var entity = GetById(id);
            var state = BaseObavjestenjaState.CreateState(entity.StateMachine);

            return state.Hide(id);
        }

        public Model.Models.Obavjestenja Edit(int id)
        {
            var entity = GetById(id);
            var state = BaseObavjestenjaState.CreateState(entity.StateMachine);

            return state.Edit(id);
        }

        public Model.Models.Obavjestenja Delete(int id)
        {
            var entity = GetById(id);
            var state = BaseObavjestenjaState.CreateState(entity.StateMachine);

            return state.Delete(id);
        }

    }
}
