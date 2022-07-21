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
            
            //UC3
            //Ride[] multiRides = { new Ride(10, 15), new Ride(15, 25) };
            //Console.WriteLine(invoiceGenerator.CalculateTotalEnhancedFare(multiRides));

            //UC4
            double fare = invoiceGenerator.CalculateFare(15,25);
            Console.WriteLine("Total fare : " + fare);
            Console.ReadLine();
        }
    }
} 