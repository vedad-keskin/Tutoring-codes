// using eCommerce.Model;
// using eCommerce.Model.SearchObjects;
// using eCommerce.Model.Responses;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace eCommerce.Services
// {
//     public class DummyProductService : IProductService
//     {
//         public virtual async Task<List<ProductResponse>> GetAsync(ProductSearchObject search)
//         {
//             List<Product> products = new List<Product>();
//             products.Add(new Product()
//             {
//                 Id = 1,
//                 Code = "Laptop"
//             });
            
//             var queryable = products.AsQueryable();

//             if (!string.IsNullOrWhiteSpace(search?.Code))
//             {
//                 queryable = queryable.Where(x => x.Code == search.Code);
//             }
            
//             if(!string.IsNullOrWhiteSpace(search?.CodeGTE))
//             {
//                 queryable = queryable.Where(x => x.Code.StartsWith(search.CodeGTE));
//             }

//             if (!string.IsNullOrWhiteSpace(search?.FTS))
//             {
//                 queryable = queryable.Where(x => x.Code.Contains(search.FTS, StringComparison.CurrentCultureIgnoreCase) || (x.Name != null && x.Name.Contains(search.FTS, StringComparison.CurrentCultureIgnoreCase)));
//             }

//             return queryable.Select(p => new ProductResponse 
//             { 
//                 Id = p.Id, 
//                 Name = p.Name ?? string.Empty, 
//                 Code = p.Code ?? string.Empty 
//             }).ToList();
//         }

//         public virtual async Task<ProductResponse?> GetByIdAsync(int id)
//         {
//             var product = new Product()
//             {
//                 Id = 1,
//                 Code = "Laptop"
//             };
            
//             return new ProductResponse 
//             { 
//                 Id = product.Id, 
//                 Name = product.Name ?? string.Empty, 
//                 Code = product.Code ?? string.Empty 
//             };
//         }
//     }
// }
