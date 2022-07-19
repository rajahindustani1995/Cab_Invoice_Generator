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
            Console.WriteLine(invoiceGenerator.CalculateFare(10, 15));
            Console.ReadLine();
        }
    }
}