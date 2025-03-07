using MapsterMapper;
using Microsoft.IdentityModel.Tokens;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Services
{
    public class GradoviService : BaseCRUDService<Model.Models.Gradovi, GradoviSearchObject, Database.Gradovi, GradoviUpsertRequest, GradoviUpsertRequest>, IGradoviService
    {
        public GradoviService(RidewithmeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IQueryable<Database.Gradovi> AddFilter(GradoviSearchObject searchObject, IQueryable<Database.Gradovi> query)
        {
            if (!string.IsNullOrEmpty(searchObject.NazivGTE))
            {
                query = query.Where(x => x.Naziv.Contains(searchObject.NazivGTE));
            }
            return query;
        }


        public Model.Models.Gradovi Delete(int id)
        {
            var set = Context.Set<Database.Gradovi>();

            var entity = set.Find(id);

            var voznjeGrad = Context.Voznje.Where(x => x.GradOdId == id || x.GradDoId == id).ToList();
            var replacement = Context.Gradovi.FirstOrDefault(x => x.Id != id).Id;

            foreach (var v in voznjeGrad)
            {  
                if(v.GradOdId == id)
                {
                   if(replacement == null)
                    {
                        Context.Remove(v);
                    } else
                    {
                        v.GradOdId = replacement;
                        v.StateMachine = "draft";
                    }

                }

                if(v.GradDoId == id)
                {
                    if (replacement == null)
                    {
                        Context.Remove(v);
                    }
                    else
                    {
                        v.GradDoId = replacement;
                        v.StateMachine = "draft";

                    }
                }
            }

            Context.SaveChanges();

            set.Remove(entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Gradovi>(entity);
        }
    }
}
