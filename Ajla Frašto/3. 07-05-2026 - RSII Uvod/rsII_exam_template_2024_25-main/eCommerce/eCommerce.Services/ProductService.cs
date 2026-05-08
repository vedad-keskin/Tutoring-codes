using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Model.Responses;
using eCommerce.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Model.Requests;
using MapsterMapper;
using eCommerce.Services.ProductStateMachine;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
namespace eCommerce.Services
{
    public class ProductService : BaseCRUDService<ProductResponse, ProductSearchObject, Database.Product, ProductInsertRequest, ProductUpdateRequest>, IProductService
    {
        protected readonly BaseProductState _baseProductState;

        public ProductService(eCommerceDbContext context, IMapper mapper, BaseProductState baseProductState) : base(context, mapper)
        {
            _baseProductState = baseProductState;
        }

        protected override IQueryable<Database.Product> ApplyFilter(IQueryable<Database.Product> query, ProductSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.FTS))
            {
                query = query.Where(p => p.Name.Contains(search.FTS) || p.Description.Contains(search.FTS));
            }

            query = query.Include(x => x.Assets);

            return query;
        }

        public override async Task<ProductResponse> CreateAsync(ProductInsertRequest request)
        {
            var baseState = _baseProductState.GetProductState("InitialProductState");
            var result = await baseState.CreateAsync(request);

            return result;
            // return base.CreateAsync(request);
        }

        public override async Task<ProductResponse?> UpdateAsync(int id, ProductUpdateRequest request)
        {
            var entity = await _context.Products.FindAsync(id);
            //check if entity is null
            if (entity == null)
            {
                throw new UserException("Product not found");
            }
            var baseState = _baseProductState.GetProductState(entity.ProductState);
            return await baseState.UpdateAsync(id, request);
            // return base.UpdateAsync(id, request);
        }

        public async Task<ProductResponse> ActivateAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            var baseState = _baseProductState.GetProductState(entity.ProductState);

            return await baseState.ActivateAsync(id);
        }

        public async Task<ProductResponse> DeactivateAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            var baseState = _baseProductState.GetProductState(entity.ProductState);

            return await baseState.DeactivateAsync(id);
        }

        public List<string> AllowedActions(int id)
        {
            if (id <= 0)
            {
                var initialBaseState = _baseProductState.GetProductState("InitialProductState");
                return initialBaseState.AllowedActions(id);
            }

            var entity = _context.Products.Find(id);
            if (entity == null)
            {
                throw new UserException("Product not found");
            }
            var baseState = _baseProductState.GetProductState(entity.ProductState);
            return baseState.AllowedActions(id);
        }

        public async Task CreateDummyOrderDataAsync(int userId, int numberOfOrders = 10)
        {
            for (int i = 0; i < numberOfOrders; i++)
            {
                await CreateRandomOrderAsync(userId);
            }
        }

        public async Task<Order> CreateRandomOrderAsync(int userId, int minProducts = 1, int maxProducts = 5)
        {
            // Get all products
            var products = await _context.Products.ToListAsync();
            if (products.Count == 0)
                throw new Exception("No products available to order.");

            var rnd = new Random();
            int numProducts = rnd.Next(minProducts, Math.Min(maxProducts, products.Count) + 1);
            var selectedProducts = products.OrderBy(x => rnd.Next()).Take(numProducts).ToList();

            // Create order
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                TotalAmount = 0, // will be calculated
                OrderItems = new List<OrderItem>(),
                ShippingAddress = "Random Address",
                ShippingCity = "Random City",
                ShippingState = "Random State",
                ShippingZipCode = "00000",
                ShippingCountry = "Random Country"
            };

            decimal total = 0;
            foreach (var product in selectedProducts)
            {
                int quantity = rnd.Next(1, 4); // 1-3 items per product
                decimal unitPrice = product.Price; // assumes Product has Price property
                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    Discount = 0
                };
                total += quantity * unitPrice;
                order.OrderItems.Add(orderItem);
            }
            order.TotalAmount = total;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }


        public List<ProductResponse> Recommend(int id)
        {
            var mlContext = new MLContext();

            var tmpData = _context.Orders
                .Include(o => o.OrderItems).ToList();

            var data = new List<ProductEntry>();

            foreach (var item in tmpData)
            {
                if (item.OrderItems?.Count > 1)
                {
                    var distinctItemId = item.OrderItems
                        .Select(x => x.ProductId)
                        .Distinct()
                        .ToList();

                    distinctItemId.ForEach(y =>
                    {
                        var relatedItems = item.OrderItems.Where(z => z.ProductId != y);
                        foreach (var z in relatedItems)
                        {
                            data.Add(new ProductEntry
                            {
                                ProductId = (uint)y,
                                CoPurchaseProductId = (uint)z.ProductId,
                            });
                        }

                    });

                }
            }

            var traindata = mlContext.Data.LoadFromEnumerable(data);

            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductId);
            options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductId);
            options.LabelColumnName= "Label";
            options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
            options.Alpha = 0.01;
            options.Lambda = 0.025;
            // For better results use the following parameters
            options.NumberOfIterations = 100;
            options.C = 0.00001;

            var estimator = mlContext.Recommendation().Trainers.MatrixFactorization(options);

            var model = estimator.Fit(traindata);

            var products = _context.Products.Where(x => x.Id != id).ToList();

            var predictionResults = new List<(Database.Product, float)>();
            foreach (var product in products)
            {
                var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, CoPurchasePrediction>(model);
                var prediction = predictionengine.Predict(new ProductEntry
                {
                    ProductId = (uint)id,
                    CoPurchaseProductId = (uint)product.Id
                });

                predictionResults.Add((product, prediction.Score));
            }

            var finalResults = predictionResults
                .OrderByDescending(x => x.Item2)
                .Take(10) // Get top 10 recommendations
                .Select(x => _mapper.Map<ProductResponse>(x.Item1))
                .ToList();

            return finalResults;
        }

    }

    public class CoPurchasePrediction
    {
        public float Score { get; set; }
    }

    class ProductEntry
    {
        [KeyType(count: 1000)]
        public uint ProductId { get; set; }
        [KeyType(count: 1000)]
        public uint CoPurchaseProductId { get; set; }
        public float Label { get; set; }
    }
}
