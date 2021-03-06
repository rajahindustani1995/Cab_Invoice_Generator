using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CabInvoiceGenerator.RideMode;

namespace CabInvoiceGenTestProject
{
    [TestClass]
    public class CabInvoiceTestClass
    {
        InvoiceGenerator invoiceGenerator = null;

        //UC1 Calculate total fare
        [TestMethod]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 15;
            int time = 10;
            //Act
            double fare = invoiceGenerator.CalculateFare(time , distance);
            double expected = 160;
            //Assert
            Assert.AreEqual(expected, fare);
        }

        //UC2 Add multiple rides
        // Test Case 2 : For Multiple Rides
        [TestMethod]
        public void GivenMultipleRidesReturnAggregateFare()
        {
            //Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double actual, expected = 375;  //215+160 = 375/-
            int time = 10; //10*1 =10
            double distance = 15;  //15*10=150
            Ride[] cabRides = new Ride[]
            {
                new Ride(10, 15), //160
                new Ride(15, 20)  //15*1+20*10=215
            };

            //Act
            actual = invoiceGenerator.CalculateAgreegateFare(cabRides);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        //UC3-Enhanced Invoice
        [TestMethod]
        public void GivenInvoiceReturnNumOfRideTotalFareandAverageFare() 
        {
            //Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] cabRides = new Ride[]
            {
                new Ride(10, 15), //160
                new Ride(15, 20)  //15*1+20*10=215
            };
            double totalfare = 375;
            InvoiceSummary expected = new InvoiceSummary(cabRides.Length, totalfare);  //215+160 = 375/-

            //Act
            var actual = invoiceGenerator.CalculateTotalEnhancedFare(cabRides);

            //Assert 
            Assert.AreEqual(actual, expected);
        }

        //UC4 Given userId should return Invoice Summary
        [TestMethod]
        public void GivenUserIdShouldReturnInvoice()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(5 , 2.0), new Ride(1,0.1) };
            string userId = "001";
            invoiceGenerator.AddRides(userId, rides);
            string userIdForSecondUser = "002";
            Ride[] ridesForSeconndUser = { new Ride(10,3.0), new Ride(2 ,0.1) };
            invoiceGenerator.AddRides(userIdForSecondUser, ridesForSeconndUser);

            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }

        //UC5 Calculate fare for Primium ride
        [TestMethod]
        public void GivenDistanceAndTimeReturnTotalFair()
        {
            //Arrange
            double distance = 2;
            int time = 5;
            double expected = 25;
            InvoiceGenerator generator = new InvoiceGenerator(RideType.NORMAL);

            //Act
            double actual = generator.CalculateFare(time,distance);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void GivenDistanceAndTimeReturnTotalFairForPrimiumRides()
        {
            //Arrange
            double distance = 2;
            int time = 5;
            double expected = 40;
            InvoiceGenerator generator = new InvoiceGenerator(RideType.PREMIUM);

            //Act
            double actual = generator.CalculateFare(time, distance);

            Assert.AreEqual(expected, actual);
        }
    }
}