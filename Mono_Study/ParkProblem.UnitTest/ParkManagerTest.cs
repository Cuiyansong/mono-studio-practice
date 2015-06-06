using System;
using NUnit.Framework;

namespace ParkProblem.UnitTest
{
	[TestFixture ()]
	public class ParkManagerTest
	{
		[Test ()]
		public void  Should_take_out_my_car_when_I_have_parked_my_car ()
		{
			var park = new Parklot ();
			var myCar = new Car ("123");
			var parkBoy = new ParkBoy (park);

			park.ParkIn (myCar);

			Assert.True (myCar.Equals (parkBoy.TakeOut ("123")));
		}
	}
}

