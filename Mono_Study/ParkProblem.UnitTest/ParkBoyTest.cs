using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace ParkProblem.UnitTest
{
	[TestFixture ()]
	public class ParkBoyTest
	{
		[Test()]
		public void  Should_take_out_my_car_when_I_have_parked_my_car()
		{
			var park = new Parklot ();
			var myCar = new Car ("123");
			var parkBoy = new ParkBoy (park);

			park.ParkIn (myCar);

			Assert.True (myCar.Equals(parkBoy.TakeOut("123")));
		}

		[Test()]
		public void Should_take_out_my_car_by_myself_when_parkBoy_park_my_car()
		{			
			var park = new Parklot ();
			var myCar = new Car ("123");			
			var parkBoy = new ParkBoy (park);

			parkBoy.ParkIn (myCar);

			Assert.True (myCar.Equals(park.TakeOut ("123")));
		}

		[Test()]
		public void Should_park_car_in_the_most_empty_parklot_when_there_are_two_parklot_for_parking()
		{			
			var park1 = new Parklot ();
			park1.ParkIn (new Car ("A"));
			var park2 = new Parklot ();
			park2.ParkIn (new Car ("B"));
			park2.ParkIn (new Car ("C"));
			var myCar = new Car ("MyCar");
			var parklots = new List<Parklot> ();
			parklots.Add (park1);
			parklots.Add (park2);
			var parkBoy = new ParkBoy (parklots);

			parkBoy.ParkIn (myCar);
 
			Assert.True (park1.Capacity.Equals(park2.Capacity));
		}
	}
}

