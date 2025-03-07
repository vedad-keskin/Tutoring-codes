using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using ridewithme.Model.Exceptions;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.ObavjestenjaStateMachine
{
    public class BaseObavjestenjaState
    {
        public RidewithmeContext Context { get; set; }

        public IMapper Mapper { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
        public BaseObavjestenjaState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider)
        {
            Context = dbContext;
            Mapper = mapper;
            ServiceProvider = serviceProvider;
        }
        public virtual Model.Models.Obavjestenja Insert(ObavjestenjaInsertRequest request)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Obavjestenja Activate(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Obavjestenja Edit(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }


        public virtual Model.Models.Obavjestenja Complete(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Obavjestenja Hide(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Obavjestenja Update(int id, ObavjestenjaUpdateRequest request)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual Model.Models.Obavjestenja Delete(int id)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public virtual List<string> AllowedActions(Database.Obavjestenja entity)
        {
            throw new UserException("Metoda nije dozvoljena.");
        }

        public BaseObavjestenjaState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialObavjestenjaState>();

                case "active":
                    return ServiceProvider.GetService<ActiveObavjestenjaState>();

                case "draft":
                    return ServiceProvider.GetService<DraftObavjestenjaState>();

                case "hidden":
                    return ServiceProvider.GetService<HiddenObavjestenjaState>();

                case "completed":
                    return ServiceProvider.GetService<CompletedObavjestenjeState>();

                default: throw new Exception("State not recognized.");
            }
        }
    }
}

