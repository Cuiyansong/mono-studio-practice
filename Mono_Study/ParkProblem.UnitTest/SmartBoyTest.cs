using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace ParkProblem.UnitTest
{
	[TestFixture ()]
	public class SmartBoyTest
	{
		[Test()]
		public void  Should_park_my_car_in_first_parklot_when_first_parklot_is_the_most_empty_in_two_parklots()
		{
			var parkOne = new Parklot (1){ParklotId = "One"};
			var parkTwo = new Parklot (10){ParklotId = "Two"};
			var myCar = new Car ("123");

			var parklots = new List<Parklot> ();
			parklots.Add (parkOne);
			parklots.Add (parkTwo);
			var parkBoy = new SmartBoy ();
			parkBoy.AddParkLot (parklots);

			parkBoy.ParkIn (myCar);

			Assert.True (parkOne.ContainsCar("123"));
		}

		[Test()]
		public void  Should_park_my_car_in_second_parklot_when_second_parklot_is_the_most_empty_in_two_parklots()
		{
			var parkOne = new Parklot (10){ParklotId = "One"};
			var parkTwo = new Parklot (1){ParklotId = "Two"};
			var myCar = new Car ("123");

			var parklots = new List<Parklot> ();
			parklots.Add (parkOne);
			parklots.Add (parkTwo);
			var parkBoy = new SmartBoy ();
			parkBoy.AddParkLot (parklots);

			parkBoy.ParkIn (myCar);

			Assert.True (parkTwo.ContainsCar("123"));
		}
	}
}