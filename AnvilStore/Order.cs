using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnvilStore
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { private set; get; }
        public string CustomerAddress { private set; get; }
        public string CustomerCity { private set; get; }
        public string CustomerState { private set; get; }
        public string CustomerZip { private set; get; }
        public int OrderQuantity { get; set; }

        public Order(string customerName, string customerAddress, string customerCity, string customerState, string customerZip, int orderQuantity)
        {
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.CustomerCity = customerCity;
            this.CustomerState = customerState;
            this.CustomerZip = customerZip;
            this.OrderQuantity = orderQuantity;
        }


        //Below is where all the calculations are done using the values from the Constants class.
        public decimal CalculateOrderShippingCost()
        {
            if(this.OrderQuantity < 5 || this.CustomerState == "CA" || this.CustomerState == "OR")
            {
                return (decimal)0;
            }
            else
            {
                return (decimal)this.OrderQuantity * Constants.Shipping.Amount;
            }
            
        }
        public decimal CalculateBaseCostWithBulkOrderDiscount()
        {
            decimal baseCost;
            if (this.OrderQuantity < 10)
            {
                baseCost = (decimal)this.OrderQuantity * Constants.BulkDiscount.LessThanTen;
            }
            else if(this.OrderQuantity < 20 && this.OrderQuantity > 10)
            {
                baseCost = (decimal)this.OrderQuantity * Constants.BulkDiscount.BetweenTenAndNineteen;
            }
            else
            {
                baseCost = (decimal)this.OrderQuantity * Constants.BulkDiscount.MoreThanNineteen;
            }
            return baseCost;
        }
        public decimal CalculateWithSalesTax()
        {
            return this.CalculateBaseCostWithBulkOrderDiscount() * Constants.Tax.Amount;
        }
        public decimal CalculateOrderTotal()
        {
            return CalculateOrderShippingCost() + CalculateWithSalesTax();
        }

        //This could be made more efficient but that isn't a high priority for this assignment due to shortage of time.
        public void PrintInvoice()
        {
            Console.WriteLine("\n\n\t\tInvoice\n\n\t\tThe Anvil Store\n\t\t222 Beach Drive\n\t\tBeachCity, CA 12221");
            Console.WriteLine($"\t\t{DateTime.Now}");
            Console.Write(String.Format($"\n\t\t\t\tShip To\n"));
            Console.Write(String.Format($"\t\t\t\t{this.CustomerName}\n"));
            Console.WriteLine(String.Format($"\t\t\t\t{this.CustomerAddress}"));
            Console.WriteLine(String.Format($"\t\t\t\t{this.CustomerCity}, {this.CustomerState} {this.CustomerZip}"));
            Console.WriteLine();
            Console.WriteLine();
            String s = String.Format("{0,-20} {1,-20}\n\t\t\t", "Quantity", "Total");
            
            s += String.Format("{0,-20} ${1,-20:00.00}\n",
                      this.OrderQuantity, this.CalculateOrderTotal());
            Console.WriteLine($"\t\t\t{s}");
            String s2 = String.Format("{0,-20} {1,-20}\n\t\t\t", "Tax Rate", "Total Tax");

            s2 += String.Format("{0,-20} ${1,-20:00.00}\n",
                      Constants.Tax.TaxRateAsString, this.CalculateWithSalesTax() - this.CalculateBaseCostWithBulkOrderDiscount());
            Console.WriteLine($"\t\t\t{s2}");
            String s3 = String.Format("{0,-20} {1,-20}\n\t\t\t", "Shipping Per Anvil", "Total Shipping");

            s3 += String.Format("{0,-20} ${1,-20:00.00}\n",
                      Constants.Shipping.ShippingAsString, CalculateOrderShippingCost());
            Console.WriteLine($"\t\t\t{s3}");
        }
    }
}
