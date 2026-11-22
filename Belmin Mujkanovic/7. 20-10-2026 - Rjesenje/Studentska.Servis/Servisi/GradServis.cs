using Microsoft.EntityFrameworkCore;
using Studentska.Data.Entiteti;
using Studentska.Data.IspitIB180079;

namespace Studentska.Servis.Servisi
{
    public class GradServis : BaseServis<Grad>
    {


        public List<Grad> GetAllIncluded()
        {
            //     db.KnjigeIB180079.ToList();
            return _dbContext
                .Set<Grad>()
                .Include(x => x.Drzava)
                .ToList();

        }






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
