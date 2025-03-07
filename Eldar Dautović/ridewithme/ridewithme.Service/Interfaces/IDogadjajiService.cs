using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Interfaces
{
    public interface IDogadjaji : ICRUDService<Dogadjaji, DogadjajiSearchObejct, DogadjajiUpsertRequest, DogadjajiUpsertRequest>
    {
        public Dogadjaji Delete(int id);

    }
}
