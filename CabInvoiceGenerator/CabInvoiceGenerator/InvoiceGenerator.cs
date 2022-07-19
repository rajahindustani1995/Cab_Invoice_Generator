using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CabInvoiceGenerator.RideMode;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        
        private readonly int MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly int MINIMUM_FARE;
        public RideType rideType;

        // Create Parameterized constructor
        public InvoiceGenerator(RideMode.RideType rideType)
        {
            this.rideType = rideType;

            if(RideMode.RideType.NORMAL== rideType)
            {
                MINIMUM_COST_PER_KM = 10;
                COST_PER_TIME = 1;
                MINIMUM_FARE = 5;
            }
          
        }

        //UC1 = FOR SINGLE RIDE
        public double CalculateFare(double distance , int time)
        {
            try
            {
                if(distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE,"distsnce is invalid"); 
                }
                if(time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "time is invalid");

                }
                else
                {
                    double totalFare = 0;
                    //Calculating Total Fare For Single Ride
                    totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
                    return Math.Max(totalFare, MINIMUM_FARE);
                }
                
            }
            catch(CabInvoiceException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
