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
    public interface IKorisniciService : ICRUDService<Korisnici, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        Korisnici Login(string username, string password);

        Korisnici GetLoggedInUser(string username);
        Korisnici Delete(int id);

        PovjerljivVozac Trusted(int vozacId, int korisnikId);

        List<Model.Models.Korisnici> Popular();

    }
}
