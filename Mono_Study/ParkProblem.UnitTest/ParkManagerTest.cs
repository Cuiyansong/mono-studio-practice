using System;
using NUnit.Framework;

namespace ParkProblem.UnitTest
{
	[TestFixture ()]
	public class ParkManagerTest
	{
		[Test ()]
		public void Should_park_car_fail_when_parklot_has_no_space ()
		{
			var park = new Parklot (1);
			park.ParkIn (new Car ("Full"));
			var myCar = new Car ("123");
			var parkManager = new ParkManager ();
			parkManager.AddParkLot (park);

			bool isParkIn = parkManager.ParkIn (myCar);

			Assert.True (isParkIn == false);
		}

		[Test ()]
		public void  Should_park_car_success_when_parklot_has_space ()
		{
			var park = new Parklot ();
			var myCar = new Car ("123");
			var parkManager = new ParkManager ();
			parkManager.AddParkLot (park);

			 Assert.True (parkManager.ParkIn (myCar), "Should be park in success");
			 Assert.True (myCar.Equals (parkManager.TakeOut ("123")));
		}

		[Test ()]
		public void Should_park_car_fail_when_parklot_has_no_space_and_has_parkboy ()
		{
			var park = new Parklot (1);
			park.ParkIn (new Car ("Full"));
			var myCar = new Car ("123");
			var parkManager = new ParkManager ();
			parkManager.AddParkLot (park);
			var parkBoy = new ParkBoy ();
			parkManager.AddParkBoy (parkBoy);

			bool isParkIn = parkManager.ParkIn (myCar);

			Assert.True (isParkIn == false);
		}

		[Test ()]
		public void Should_park_car_success_when_parklot_has_space_and_has_parkboy_with_parklot ()
		{
			var park = new Parklot ();
			park.ParkIn (new Car ("Full"));
			var myCar = new Car ("123");
			var parkManager = new ParkManager ();
			var parkBoy = new ParkBoy ();
			parkBoy.AddParkLot (park);
			parkManager.AddParkBoy (parkBoy);

			parkManager.ParkIn (myCar);

			Assert.True (myCar.Equals (parkManager.TakeOut ("123")));
		}

		[Test ()]
		public void Should_park_car_success_when_manager_has_empty_parklot_and_has_parkboy_without_parklot ()
		{
			var park = new Parklot ();
			var myCar = new Car ("123");
			var parkManager = new ParkManager ();
			parkManager.AddParkLot (park);
			var parkBoy = new ParkBoy ();
			parkManager.AddParkBoy (parkBoy);

			parkManager.ParkIn (myCar);

			Assert.True (myCar.Equals (parkManager.TakeOut ("123")));
		}
	}
}

