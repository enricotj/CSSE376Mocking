using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestClass]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[TestInitialize]
		public void TestInitialize()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[TestMethod]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}

        [TestMethod]
        public void TestThatCarDoesGetLocationFromTheDatabase()
        {
            IDatabase mockDB = mocks.StrictMock<IDatabase>();

            String carLocation = "pi";
            String otherCarLocation = "cyberspace";

            Expect.Call(mockDB.getCarLocation(314)).Return(carLocation);
            Expect.Call(mockDB.getCarLocation(42)).Return(otherCarLocation);

            mocks.ReplayAll();

            Car target = new Car(2);
            target.Database = mockDB;

            String result;

            result = target.getCarLocation(314);
            Assert.AreEqual(carLocation, result);

            result = target.getCarLocation(42);
            Assert.AreEqual(otherCarLocation, result);

            mocks.VerifyAll();
        }

        [TestMethod]
        public void TestThatCareDoesGetMileageFromDatabase()
        {
            IDatabase mockDB = mocks.StrictMock<IDatabase>();
            Int32 Mileage = 525600;
            
            Expect.Call(mockDB.Miles).PropertyBehavior();

            mocks.ReplayAll();

            mockDB.Miles = Mileage;

            var target = new Car(2);
            target.Database = mockDB;

            int mileage = target.Mileage;
            Assert.AreEqual(mileage, Mileage);

            mocks.VerifyAll();
        }

	}
}
