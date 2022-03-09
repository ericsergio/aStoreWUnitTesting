using System;

namespace AnvilStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //***************Testing the Data class - uncomment to test************************
            //Data data = new Data();
            //data.DisplayStateValues();
            //data.CheckState("AA");
            //*********************************************************************************

            //*********************************************************************************
            //Below will run the main application code
            Customer customer0 = new();
            customer0.CollectCustomerInfo();
            //*********************************************************************************
        }
    }
}
