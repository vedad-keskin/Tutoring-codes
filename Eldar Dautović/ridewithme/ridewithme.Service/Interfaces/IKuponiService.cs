using ridewithme.Model.SearchObject;
using ridewithme.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ridewithme.Model.Models;

namespace ridewithme.Service.Interfaces
{
    public interface IKuponiService : ICRUDService<Kuponi, KuponiSearchObject, KuponiInsertRequest, KuponiUpdateRequest>
    {
        public Kuponi Activate(int id);
        public Kuponi Hide(int id);
        public Kuponi Edit(int id);

        public Kuponi Delete(int id);

        public ProvjerenKupon Check(string kod);
        public List<string> AllowedActions(int id);
    }
}
