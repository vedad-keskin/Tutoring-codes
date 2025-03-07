using ridewithme.Model.Helpers;
using ridewithme.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Interfaces
{
    public interface IStatistikaService
    {
        public PagedResult<Statistika> GetList();

        public UkupnaStatistika GetMonthlyStatistics();

        public List<PoslovniIzvjestaj> GetBusinessReport();
    }
}
