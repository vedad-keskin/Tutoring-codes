using Studentska.Data.Entiteti;

namespace Studentska.Servis.Servisi
{
    public class GradServis : BaseServis<Grad>
    {        
        public List<Grad> GetByNaziv(string nazivGrada)
        {
            return _dbContext.Gradovi.Where(grad => grad.Naziv.Contains(nazivGrada)).ToList();
        }

        public List<Grad> GetByDrzavaId(int drzavaId)
        {
            return _dbContext.Gradovi.Where(grad => grad.DrzavaId == drzavaId).ToList();
        }    
    }
}
