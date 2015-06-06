using NUnit.Framework;
using System;

namespace ParkProblem.UnitTest
{
	[TestFixture ()]
	public class ParkinglotTest
	{  
		[Test ()]
		public void Should_park_in_when_park_capacity_allow ()
		{
			var park = new Parklot ();

			Assert.True(park.ParkIn (new Car("ABC")));
		}

		[Test ()]
		public void Should_not_park_in_when_park_capacity_not_allow ()
		{
			var park = new Parklot (0);

			Assert.True(!park.ParkIn (new Car("ABC")));
		}

		[Test ()]
		public void Should_take_out_car_when_park_contains_car ()
		{
			var park = new Parklot ();

			park.ParkIn (new Car("MyCar"));

			Assert.True(park.TakeOut ("MyCar").Id.Equals("MyCar"));
		}

		[Test ()]
		public void Should_not_take_out_car_when_park_not_contains_car ()
		{
			var park = new Parklot ();

			Assert.True(park.TakeOut ("MyCar") == null);
		}
	}
}

