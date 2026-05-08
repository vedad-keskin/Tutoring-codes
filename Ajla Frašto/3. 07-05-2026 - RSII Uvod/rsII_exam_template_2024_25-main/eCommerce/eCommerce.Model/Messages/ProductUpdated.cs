using System;
using System.Collections.Generic;
using System.Text;
using eCommerce.Model.Responses;

namespace eCommerce.Model.Messages
{
    public class ProductUpdated
    {
        public ProductResponse Product { get; set; }
    }
}
