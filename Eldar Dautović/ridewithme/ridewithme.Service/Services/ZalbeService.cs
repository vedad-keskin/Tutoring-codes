using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using ridewithme.Service.ZalbeStateMachine;
using System.Linq.Dynamic.Core;


namespace ridewithme.Service.Services
{
    public class ZalbeService : BaseCRUDService<Model.Models.Zalbe, ZalbeSearchObject, Database.Zalbe, ZalbeInsertRequest, ZalbeUpdateRequest>, IZalbeService
    {
        public BaseZalbeState BaseZalbeState { get; set; }

        public ZalbeService(RidewithmeContext dbContext, IMapper mapper, BaseZalbeState baseZalbeState) : base(dbContext, mapper)
        {
            BaseZalbeState = baseZalbeState;
        }

        public override IQueryable<Database.Zalbe> AddFilter(ZalbeSearchObject searchObject, IQueryable<Database.Zalbe> query)
        {
            if (!string.IsNullOrWhiteSpace(searchObject.NaslovGTE))
            {
                query = query.Where(x => x.Naslov.Contains(searchObject.NaslovGTE));
            }

            if (searchObject.DatumPreuzimanja.HasValue)
            {
                query = query.Where(x => x.DatumPreuzimanja == searchObject.DatumPreuzimanja.Value);
            }

            if (searchObject.KorisnikId.HasValue)
            {
                query = query.Where(x => x.KorisnikId == searchObject.KorisnikId.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchObject.VrstaZalbeGTE))
            {
                query = query.Include(x => x.VrstaZalbe).Where(x => x.VrstaZalbe.Naziv.Contains(searchObject.VrstaZalbeGTE));
            }

            if (searchObject.IsVrstaZalbeIncluded.HasValue && searchObject.IsVrstaZalbeIncluded == true)
            {
                query = query.Include(x => x.VrstaZalbe);
            }

            if (searchObject.IsAdministratorIncluded.HasValue && searchObject.IsAdministratorIncluded == true)
            {
                query = query.Include(x => x.Administrator);
            }

            if (searchObject.IsKorisnikIncluded.HasValue && searchObject.IsKorisnikIncluded == true)
            {
                query = query.Include(x => x.Korisnik);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoImeAdministratorGTE))
            {
                query = query.Where(x => x.Administrator.KorisnickoIme.Contains(searchObject.KorisnickoImeAdministratorGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoImeKorisnikGTE))
            {
                query = query.Where(x => x.Korisnik.KorisnickoIme.Contains(searchObject.KorisnickoImeKorisnikGTE));
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

        public override Model.Models.Zalbe Insert(ZalbeInsertRequest request)
        {
            var state = BaseZalbeState.CreateState("initial");
            return state.Insert(request);
        }

        public Model.Models.Zalbe Processing(int id, int administratorId)
        {
            var entity = GetById(id);
            var state = BaseZalbeState.CreateState(entity.StateMachine);

            return state.Processing(id, administratorId);
        }

        public Model.Models.Zalbe Activate(int id)
        {
            var entity = GetById(id);
            var state = BaseZalbeState.CreateState(entity.StateMachine);

            return state.Activate(id);
        }

        public Model.Models.Zalbe Delete(int id)
        {
            var entity = GetById(id);
            var state = BaseZalbeState.CreateState(entity.StateMachine);

            return state.Delete(id);
        }

        public Model.Models.Zalbe Complete(int id, ZalbeCompleteRequest request)
        {
            var entity = GetById(id);
            var state = BaseZalbeState.CreateState(entity.StateMachine);

            return state.Complete(id, request);
        }

        public List<string> AllowedActions(int id)
        {
            if (id <= 0)
            {
                var state = BaseZalbeState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = Context.Zalbe.Find(id);
                var state = BaseZalbeState.CreateState(entity.StateMachine);
                return state.AllowedActions(entity);
            }
        }
    }
}
