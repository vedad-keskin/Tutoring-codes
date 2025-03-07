using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ridewithme.Model.Exceptions;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.VoznjeStateMachine
{
    public class ActiveVoznjeState : BaseVoznjeState
    {
        private readonly IEmailService _emailService;
        public ActiveVoznjeState(RidewithmeContext dbContext, IMapper mapper, IServiceProvider serviceProvider, IEmailService emailService) : base(dbContext, mapper, serviceProvider)
        {
            _emailService = emailService;
        }

        public override Model.Models.Voznje Hide(int id)
        {
            var set = Context.Set<Database.Voznje>();

            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            Context.SaveChanges();

            return Mapper.Map<Model.Models.Voznje>(entity);
        }

        public override Model.Models.Voznje Book(int id, VoznjeBookRequest request)
        {

            var set = Context.Set<Database.Voznje>().Include(x => x.Vozac).Include(x => x.GradDo).Include(x => x.GradOd);

            var entity = set.FirstOrDefault(x => x.Id == id);
            var klijent = Context.Korisnicis.Find(request.KlijentId);

            const double provizija = 2.0; 
            
            double totalPrice = entity.Cijena + provizija; 

            if(klijent == null)
            {
                throw new UserException("Korisnik sa tim ID-om ne postoji.");
            }

            if (entity.VozacId == request.KlijentId)
            {
                throw new UserException("Ne možete biti i vozač i klijent.");
            }

            if (klijent != null)
            {
                var klijentRides = Context.Voznje.FirstOrDefault(x => (x.KlijentId == request.KlijentId || x.VozacId == request.KlijentId) && (x.StateMachine == "booked" || x.StateMachine == "inprogress"));

                if(klijentRides != null)
                {
                    throw new UserException("Već ste klijent/vozač u drugoj bukiranoj/aktivnoj vožnji.");
                }

                if(request.Kod != null)
                {
                    var kupon = Context.Kuponi.FirstOrDefault(x => x.Kod  == request.Kod);

                    if(kupon == null || kupon.BrojIskoristivosti == 0)  {
                        throw new UserException("Kupon nije validan.");
                    }

                    entity.KuponId = kupon.Id;

                    kupon.BrojIskoristivosti -= 1;

                    totalPrice = totalPrice * (1 - kupon.Popust);

                    if(kupon.BrojIskoristivosti == 0)
                    {
                        kupon.StateMachine = "used";
                    }

                }
 
                entity.KlijentId = request.KlijentId;
                
                entity.StateMachine = "booked";

                var mappedEntity = Mapper.Map<Model.Models.Voznje>(entity);

                Model.Messages.VoznjePaid notifikacija = new Model.Messages.VoznjePaid
                {
                    Voznja = mappedEntity,
                    klijentEmail = klijent.Email,
                    vozacEmail = mappedEntity.Vozac.Email,
                    totalPrice = totalPrice
                };

                _emailService.SendingObject(notifikacija);

                Database.Payments payments = new Database.Payments() { 
                   Payment_Id = request.Payment_Id,
                   KorisnikId = klijent.Id,
                   VoznjaId = entity.Id
                };

                Context.Add(payments);

                Context.SaveChanges();
            }

            return Mapper.Map<Model.Models.Voznje>(entity);
        }

        public override List<string> AllowedActions(Database.Voznje entity)
        {
            return new List<string>() { nameof(Hide), nameof(Book) };
        }
    }
}
