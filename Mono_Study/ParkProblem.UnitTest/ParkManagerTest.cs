using System;
using NUnit.Framework;

namespace ParkProblem.UnitTest
{
	[TestFixture ()]
	public class ParkManagerTest
	{
		[Test ()]
		public void  Should_park_car_success_when_parklot_has_space ()
		{
			var park = new Parklot ();
			var myCar = new Car ("123");
			var parkManager = new ParkManager (park);

			parkManager.ParkIn (myCar);

			Assert.True (myCar.Equals (parkManager.TakeOut ("123")));
		}

		[Test ()]
		public void Should_park_car_fail_when_parklot_has_no_space ()
		{
			var park = new Parklot (1);
			park.ParkIn (new Car ("Full"));
			var myCar = new Car ("123");
			var parkManager = new ParkManager (park);

			bool isParkIn = parkManager.ParkIn (myCar);

			Assert.True (isParkIn == false);
		}

	}
}

