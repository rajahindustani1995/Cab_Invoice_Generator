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
        
        public readonly int MINIMUM_COST_PER_KM;
        public readonly int COST_PER_TIME;
        public readonly int MINIMUM_FARE;
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
        public double CalculateFare(int time , double distance)
        {
            try
            {
                if (time <= 0) 
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "time is invalid");
                if (distance <= 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE,"distsnce is invalid");      
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
        //UC2- For Multiple rides
        public double CalculateAgreegateFare(Ride[] rides)
        {
            double totalFare = 0;
            if (rides.Length == 0)
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "No Rides Found");
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.time, ride.distance);
            }
            double agreegateFare = Math.Max(totalFare, MINIMUM_FARE);
            return agreegateFare;
        }
        
       

    }
}
