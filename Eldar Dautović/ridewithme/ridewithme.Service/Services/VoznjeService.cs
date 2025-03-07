using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ridewithme.Model.Requests;
using ridewithme.Model.SearchObject;
using ridewithme.Service.Database;
using ridewithme.Service.VoznjeStateMachine;
using System.Linq.Dynamic.Core;
using ridewithme.Service.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Mapster;


namespace ridewithme.Service.Services
{
    public class VoznjeService : BaseCRUDService<Model.Models.Voznje, VoznjeSearchObject, Database.Voznje, VoznjeInsertRequest, VoznjeUpdateRequest>, IVoznjeService
    {
        public BaseVoznjeState BaseVoznjeState { get; set; }

        public VoznjeService(RidewithmeContext dbContext, IMapper mapper, BaseVoznjeState baseVoznjeState)
            : base(dbContext, mapper)
        {
            BaseVoznjeState = baseVoznjeState;
        }

        public override IQueryable<Database.Voznje> AddFilter(VoznjeSearchObject searchObject, IQueryable<Database.Voznje> query)
        {

            var filteredQuery = base.AddFilter(searchObject, query);

            if (searchObject?.VoznjaId.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.Id == searchObject.VoznjaId.Value);
            }

            if (searchObject?.VozacId.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.VozacId == searchObject.VozacId.Value);
            }

            if (searchObject?.KlijentId.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.KlijentId == searchObject.KlijentId.Value);
            }

            if (searchObject?.IsVoznjaActivated == true)
            {
                filteredQuery = filteredQuery.Where(x => x.StateMachine == "active");
            }

            if (searchObject?.IsKorisniciIncluded == true)
            {
                filteredQuery = filteredQuery.Include(x => x.Klijent);

                filteredQuery = filteredQuery.Include(x => x.Vozac);

            }

            if (searchObject?.IsGradoviIncluded == true)
            {
                filteredQuery = filteredQuery.Include(x => x.GradOd);

                filteredQuery = filteredQuery.Include(x => x.GradDo);
            }

            if (searchObject?.GradDoId.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.GradDoId == searchObject.GradDoId.Value);
            }

            if (searchObject?.GradOdId.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.GradOdId == searchObject.GradOdId.Value);
            }

            if (searchObject?.CijenaDo.HasValue == true)
            {
                filteredQuery = filteredQuery.Where(x => x.Cijena <= searchObject.CijenaDo);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.OrderBy))
            {
                var items = searchObject.OrderBy.Split(' ');
                if (items.Length > 2 || items.Length == 0)
                {
                    throw new ApplicationException("Mozete sortirati samo po dva polja.");
                }
                if (items.Length == 1)
                {
                    filteredQuery = filteredQuery.OrderBy("@0", searchObject.OrderBy);
                }
                else
                {
                    filteredQuery = filteredQuery.OrderBy(string.Format("{0} {1}", items[0], items[1]));
                }

            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoImeVozacGTE))
            {
                filteredQuery = filteredQuery.Where(x => x.Vozac.KorisnickoIme.Contains(searchObject.KorisnickoImeVozacGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoImeKlijentGTE))
            {
                filteredQuery = filteredQuery.Where(x => x.Vozac.KorisnickoIme.Contains(searchObject.KorisnickoImeKlijentGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.Status))
            {
                filteredQuery = filteredQuery.Where(x => x.StateMachine == searchObject.Status);
            }


            filteredQuery = filteredQuery.Include(x => x.Dogadjaj);

            return filteredQuery;
        }

        public override Model.Models.Voznje Insert(VoznjeInsertRequest request)
        {
            var state = BaseVoznjeState.CreateState("initial");
            return state.Insert(request);
        }

        public override Model.Models.Voznje Update(int id, VoznjeUpdateRequest request)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Update(id, request);
        }

        public Model.Models.Voznje Start(int id, VoznjeStartRequest request)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Start(id, request);
        }
        public Model.Models.Voznje Complete(int id, VoznjeCompleteRequest request)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Complete(id, request);
        }

        public Model.Models.Voznje Activate(int id)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Activate(id);
        }
        public Model.Models.Voznje Hide(int id)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Hide(id);
        }

        public Model.Models.Voznje Edit(int id)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Edit(id);
        }

        public Model.Models.Voznje Delete(int id)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Delete(id);
        }

        public Model.Models.Voznje Rate(int id, int ocjena)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Rate(id, ocjena);
        }

        public Model.Models.Voznje Book(int id, VoznjeBookRequest request)
        {
            var entity = GetById(id);
            var state = BaseVoznjeState.CreateState(entity.StateMachine);

            return state.Book(id, request);
        }

        public List<string> AllowedActions(int id)
        {
            if (id <= 0)
            {
                var state = BaseVoznjeState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = Context.Voznje.Find(id);
                var state = BaseVoznjeState.CreateState(entity.StateMachine);
                return state.AllowedActions(entity);
            }
        }

        public List<Model.Models.Korisnici> GetParticipants(int id)
        {
            return new List<Model.Models.Korisnici>();
        }

        static MLContext mlContext = null;
        static object isLocked = new object();
        static ITransformer model = null;
        private const string ModelFilePath = "set-model.zip";
        public List<Model.Models.Voznje> Recommend(int rideId)
        {
            if (mlContext == null)
            {
                lock (isLocked)
                {
                    mlContext = new MLContext();

                    if (File.Exists(ModelFilePath))
                    {
                        using (var stream = new FileStream(ModelFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            model = mlContext.Model.Load(stream, out var modelInputSchema);
                        }
                    } else
                    {

                        var tmpData = Context.Voznje.ToList();

                        var data = new List<RideEntry>();

                        foreach (var rideTmp in tmpData)
                        {
                            var relatedRides = tmpData.Where(r => r.GradOdId == rideTmp.GradOdId && r.Id != rideTmp.Id);

                            foreach (var relatedRide in relatedRides)
                            {
                                data.Add(new RideEntry()
                                {
                                    GradOdId = (uint)rideTmp.GradOdId,
                                    RelatedRideId = (uint)relatedRide.Id
                                });
                            }
                        }

                        var trainData = mlContext.Data.LoadFromEnumerable(data);

                        var options = new MatrixFactorizationTrainer.Options
                        {
                            MatrixColumnIndexColumnName = nameof(RideEntry.GradOdId),
                            MatrixRowIndexColumnName = nameof(RideEntry.RelatedRideId),
                            LabelColumnName = "Label",
                            LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                            Alpha = 0.01f,
                            Lambda = 0.025f,
                            NumberOfIterations = 100,
                            C = 0.00001f
                        };

                        var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                        model = est.Fit(trainData);
                        using (var stream = new FileStream(ModelFilePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                        {
                            mlContext.Model.Save(model, trainData.Schema, stream);
                        }

                    }
                }
            }

            var ride = Context.Voznje.FirstOrDefault(x => x.Id == rideId);
            if (ride == null) return new List<Model.Models.Voznje>();

            var potentialRides = Context.Voznje.Include(x => x.Vozac).Include(x => x.GradOd).Include(x => x.GradDo).Where(x => x.GradOdId == ride.GradOdId && x.Id != rideId && x.StateMachine == "active");

            var predictionResult = new List<(Database.Voznje, float)>();

            foreach (var potentialRide in potentialRides)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<RideEntry, RidePrediction>(model);
                var prediction = predictionEngine.Predict(new RideEntry()
                {
                    GradOdId = (uint)ride.GradOdId,
                    RelatedRideId = (uint)potentialRide.Id
                });

                predictionResult.Add((potentialRide, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(4).ToList();

            return Mapper.Map<List<Model.Models.Voznje>>(finalResult);
        }

        public class RidePrediction
        {
            public float Score { get; set; }
        }

        public class RideEntry
        {
            [KeyType(count: 100000)]
            public uint GradOdId { get; set; }

            [KeyType(count: 100000)]
            public uint RelatedRideId { get; set; }

            public float Label { get; set; }
        }

    }
}



