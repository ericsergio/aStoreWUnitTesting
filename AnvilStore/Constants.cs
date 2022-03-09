using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnvilStore
{
    public class Constants
    {
        public class BulkDiscount
        {
            public const decimal LessThanTen = 88.50m;
            public const decimal BetweenTenAndNineteen = 70.00m;
            public const decimal MoreThanNineteen = 68.25m;
        }
        public class Shipping
        {
            //public const decimal Amount = 112.00m;
            public const decimal Amount = 150.00m;
            //public const string ShippingAsString = "$112.00";
            public const string ShippingAsString = "$150.00";
        }
        public class Tax
        {
            public const decimal Amount = 1.1085m;
            public const string TaxRateAsString = "10.85%";
        }
    }
}
