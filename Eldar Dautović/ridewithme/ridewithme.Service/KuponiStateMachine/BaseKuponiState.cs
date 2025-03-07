using MapsterMapper;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;

using Microsoft.Extensions.DependencyInjection;
using ridewithme.Model.Exceptions;


namespace ridewithme.Service.KuponiStateMachine
{
    public class BaseKuponiState
    {
        public RidewithmeContext Context { get; set; }

        public IMapper Mapper { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
        public BaseKuponiState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider)
        {
            Context = dbContext;
            Mapper = mapper;
            ServiceProvider = serviceProvider;
        }
        public virtual Model.Models.Kuponi Insert(KuponiInsertRequest request)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Kuponi Delete(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Kuponi Update(int id, KuponiUpdateRequest request)
        { 
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Kuponi Activate(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        } 
        public virtual Model.Models.Kuponi Hide(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }
        public virtual Model.Models.Kuponi Edit(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual List<string> AllowedActions(Database.Kuponi entity)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public BaseKuponiState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialKuponiState>();

                case "draft":
                    return ServiceProvider.GetService<DraftKuponiState>();

                case "hidden":
                    return ServiceProvider.GetService<HiddenKuponiState>();

                case "active":
                    return ServiceProvider.GetService<ActiveKuponiState>();

                default: throw new Exception("State not recognized.");
            }
        }
    }
}

//Initial, draft, active, hidden -> active -> used