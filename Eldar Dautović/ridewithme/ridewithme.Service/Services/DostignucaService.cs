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
    public class DostignucaService : BaseCRUDService<Model.Models.Dostignuca, DostignucaSearchObject, Database.Dostignuca, DostignucaUpsertRequest, DostignucaUpsertRequest>, IDostignucaService
    {
        public DostignucaService(RidewithmeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


    }
}
