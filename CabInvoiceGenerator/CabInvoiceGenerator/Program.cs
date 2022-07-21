using System;
using static CabInvoiceGenerator.RideMode;

namespace CabInvoiceGenerator
{
    class Program
    {
        public static void Main(string [] args)
        {
            Console.WriteLine("\t\t\t\tWelcome to Cab Invoice Generator Problem\t\t\t\t");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            //Console.WriteLine(invoiceGenerator.CalculateFare(10, 15));

            Ride[] multiRides = { new Ride(10, 15), new Ride(15, 25) };
            Console.WriteLine(invoiceGenerator.CalculateTotalEnhancedFare(multiRides));
            Console.ReadLine();
        }
    }
} 