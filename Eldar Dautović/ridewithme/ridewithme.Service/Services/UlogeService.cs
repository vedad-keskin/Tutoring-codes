using MapsterMapper;
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
    public class Ulogeervice : BaseCRUDService<Model.Models.Uloge, UlogeearchObject, Database.Uloge, UlogeUpsertRequest, UlogeUpsertRequest>, IUlogeervice
    {
        public Ulogeervice(RidewithmeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

    }
}
