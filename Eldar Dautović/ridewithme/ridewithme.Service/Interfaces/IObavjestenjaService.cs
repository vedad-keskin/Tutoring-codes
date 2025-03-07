using MapsterMapper;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Interfaces
{
    public interface IObavjestenjaService : ICRUDService<Model.Models.Obavjestenja, ObavjestenjaSearchObject, ObavjestenjaInsertRequest, ObavjestenjaUpdateRequest>
    {
        public List<string> AllowedActions(int id);
        public Model.Models.Obavjestenja Activate(int id);
        public Model.Models.Obavjestenja Hide(int id);
        public Model.Models.Obavjestenja Edit(int id);
        public Model.Models.Obavjestenja Delete(int id);
        public Model.Models.Obavjestenja Complete(int id);

    }
}
