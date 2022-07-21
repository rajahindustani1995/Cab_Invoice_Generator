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
    }
}