using System;
using System.Threading.Tasks;
using System.Linq;

namespace HttpHandler.BitsoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SetContext().Wait();
        }

        private static async Task SetContext()
        {
            var contex = new BitsoExternalContext("https://api.bitso.com/v3/");
            
            var response = await contex.AvailableBooks.HttpGetAsync(); 

            Console.WriteLine($"Data is {response.Success}");
            Console.WriteLine("Values:");
            response.Payload.ToList().ForEach(x=> {
                Console.WriteLine($"Book: {x.Book}");
                Console.WriteLine($"Minimum_amount: {x.Minimum_amount}");
                Console.WriteLine($"Maximum_amount: {x.Maximum_amount}");
                Console.WriteLine($"Minimum_price: {x.Minimum_price}");
                Console.WriteLine($"Maximum_price: {x.Maximum_price}");
                Console.WriteLine($"Minimum_value: {x.Minimum_value}");
                Console.WriteLine($"Maximum_value: {x.Maximum_value}");
                Console.WriteLine("------------");
            });
            ;

        }
    }
}
