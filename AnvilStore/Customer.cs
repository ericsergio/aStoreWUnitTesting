using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AnvilStore
{
    public class Customer
    {
        private int _InfoCount;      
        private string _FirstName;
        private string _LastName;
        private string _StreetAddress;
        private string _City;
        private string _State;
        private string _Zip;
       

        public int InfoCount { get { return _InfoCount;} set { _InfoCount = value; } }
        //Note: the Customer class has FirstName and LastName, where the Order class uses both concatenated 
        //to Create the whole Customer Name.
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string StreetAddress { get { return _StreetAddress; } set { _StreetAddress = value; } }
        public string City { get { return _City; } set { _City = value; } }
        public string State { get { return _State; } set { _State = value; } }
        public string Zip { get { return _Zip; } set { _Zip = value; } }


        public string[] Values { get; set; }
        public bool IsTest { get; set; }
        public string[] Prompt = {"First Name:", "Last Name:", "Street Address: ", "City: ", "State: ", "Zip: ", "Quantity: " };
        private string[] ValuesToTestFor;

        //this is the main constructor which should be initialized without params because the properties get populated 
        //dynamically rather than upon initialization.
        public Customer()
        {
            this.InfoCount = 0;
            this.Values = new string[Prompt.Length];
            this.IsTest = false;
        }
        //This constructor isn't used in the main application, I added it because I may need to use it for the unit tests.
        //I don't know the best way to set up unit tests for dynamic data. If needed this constructor might get used
        //to bypass the CollectCustomerInfo method which is responsible for dynamically gathering the user data by just
        //creating a new Customer with static values for the properties.
        public Customer(string firstName, string lastName, string streetAddress, string city, string state, string zip)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StreetAddress = streetAddress;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }

        public Customer(string[] valuesToTestFor)
        {
            this.ValuesToTestFor=valuesToTestFor;
            this.IsTest = true;
        }

        //This is the application's main data flow. This will collect the data needed to create the 
        //Order object that is used to build the invoice.
        public void CollectCustomerInfo()
        {            
            while (InfoCount < Prompt.Length)
            {
                Console.Write(Prompt[InfoCount]);
                string response = Console.ReadLine();
                Values[InfoCount] = response;
                InfoCount++;
            }
            Console.WriteLine("Press any key to display customer invoice");
            Console.ReadKey();
            BuildCustomerOrder();
        }
        //BuildCustomerOrder, the below method, is where the Order object is created using the values collected 
        //in the above CollectCustomerInfo method
        public void BuildCustomerOrder()
        {
            CheckThatValuesAreNotEmpty(Values);
            if(ValidateZip(Values[5]) != 1)
            {
                GetNewZip();
            }
            if (ValidateState(Values[4]) != 1)
            {
                GetNewStateCode();
            };
            if(ValidateAddress(Values[2]) != 1)
            {
                GetNewAddress();
            }
            Order order = new(customerName: (Values[0] + " " + Values[1]), customerAddress: Values[2], customerCity: Values[3],
                customerState: Values[4].ToUpper(), customerZip: Values[5], orderQuantity: Int32.Parse(Values[6]));
            order.PrintInvoice();

            Console.WriteLine();
            Console.ReadLine();
        }
        public static int ValidateState(string stateCode)
        {
            Data data = new();
            if (data.CheckState(stateCode) != 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public string GetNewStateCode()
        {
            Console.WriteLine("The state code you entered was not a valid state code. Please enter a valid state code.");
            string response = Console.ReadLine();
            Values[4] = response;
            if(ValidateState(response) == 1)
            {
                return response;
            }
            else
            {
                GetNewStateCode();
            }
            return response;            
        }
        public static int ValidateZip(string zipCode) 
        {
            if (zipCode.Length > 5 || zipCode.Length < 5)        
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public string GetNewZip()
        {
            Console.WriteLine("Please enter a valid zip code(5 numeric digits)");
            string response = Console.ReadLine();
            Values[5] = response;
            if(ValidateZip(response) == 1)
            {
                return response;
            }
            else
            {
                GetNewZip();
            }
            return response;
        }
        public bool CheckThatValuesAreNotEmpty(string[] values)
        {
            Values = values;
            for (int i = 0; i < Values.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(Values[i]))
                {
                    if (!this.IsTest)
                    {
                        Console.WriteLine($"{Prompt[i]} cannot be empty\n");
                        Console.Write($"Please enter valid value for {Prompt[i]} : ");
                        string response = Console.ReadLine();
                        Values[i] = response;
                        return false;
                    }
                    else
                    {
                        string result = Values[i];
                        Values[i] = result;
                        return false;
                    }
                };
            }
            return true;
        }
        public static int ValidateAddress(string address)
        {
            string pattern;
            pattern = @"\d{1,5}\s(\d{1,3}\w{1,2}|[A-Za-z]+)\s\w{1,2}";
            Regex rgx = new(pattern);
            if (rgx.IsMatch(address))
            {
                return 1;
            } else
            {
                return 0;
            }
        }
        public string GetNewAddress()
        {
            Console.WriteLine("Please enter a valid Address in the form: House Number Street Road prefix For example, 123 4th St or 123 Cherry dr)");
            string response = Console.ReadLine();
            Values[2] = response;
            if (ValidateAddress(response) == 1)
            {
                return response;
            }
            else
            {
                GetNewAddress();
            }
            return response;
        }
    }
}
