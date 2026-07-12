using Studentska.Data.Entiteti;

namespace Studentska.Servis.Servisi
{
    public class PredmetServis  : BaseServis<Predmet>
    {        
        public List<Predmet> GetByNaziv(string nazivPredmeta)
        {
            return _dbContext.Predmeti.Where(predmet => predmet.Naziv.Contains(nazivPredmeta)).ToList();
        }               
    }
}
