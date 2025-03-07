using MapsterMapper;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;

using Microsoft.Extensions.DependencyInjection;
using ridewithme.Model.Exceptions;


namespace ridewithme.Service.VoznjeStateMachine
{
    public class BaseVoznjeState
    {
        public RidewithmeContext Context { get; set; }

        public IMapper Mapper { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
        public BaseVoznjeState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider)
        {
            Context = dbContext;
            Mapper = mapper;
            ServiceProvider = serviceProvider;
        }
        public virtual Model.Models.Voznje Insert(VoznjeInsertRequest request)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Voznje Update(int id, VoznjeUpdateRequest request)
        { 
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Voznje Activate(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Voznje Start(int id, VoznjeStartRequest request)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }
        public virtual Model.Models.Voznje Complete(int id, VoznjeCompleteRequest request)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }
        public virtual Model.Models.Voznje Hide(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }
        public virtual Model.Models.Voznje Edit(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Voznje Delete(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Voznje Rate(int id, int ocjena)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual List<string> AllowedActions(Database.Voznje entity)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Voznje Book(int id, VoznjeBookRequest request)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public BaseVoznjeState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialVoznjeState>();

                case "draft":
                    return ServiceProvider.GetService<DraftVoznjeState>();

                case "active":
                    return ServiceProvider.GetService<ActiveVoznjeState>();

                case "hidden":
                    return ServiceProvider.GetService<HiddenVoznjeState>();

                case "booked":
                    return ServiceProvider.GetService<BookedVoznjeState>();
                
                case "inprogress":
                    return ServiceProvider.GetService<InProgressVoznjeState>();

                case "completed":
                    return ServiceProvider.GetService<CompletedVoznjeState>();

                default: throw new Exception("State not recognized.");
            }
        }
    }
}
