using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace ParkProblem.UnitTest
{
	[TestFixture ()]
	public class SuperBoyTest
	{
		[Test()]
		public void  Should_take_out_my_car_when_I_have_parked_my_car()
		{
			var park = new Parklot ();
			var myCar = new Car ("123");
			var parkBoy = new SuperBoy ();
			parkBoy.AddParkLot (park);

			park.ParkIn (myCar);

			Assert.True (myCar.Equals(parkBoy.TakeOut("123")));
		}

		[Test()]
		public void Should_take_out_my_car_by_myself_when_parkBoy_park_my_car()
		{			
			var park = new Parklot ();
			var myCar = new Car ("123");			
			var parkBoy = new SuperBoy ();
			parkBoy.AddParkLot (park);

			parkBoy.ParkIn (myCar);

			Assert.True (myCar.Equals(park.TakeOut ("123")));
		}

		[Test()]
		public void Should_park_car_in_first_parklot_when_the_fisrt_parklot_have_heigh_vacancy_rate()
		{			
			var park1 = new Parklot (5);
			park1.ParkIn (new Car ("A"));
			var park2 = new Parklot (5);
			park2.ParkIn (new Car ("B"));
			park2.ParkIn (new Car ("C"));
			var myCar = new Car ("MyCar");

			Assert.True (park1.VacancyRate > park2.VacancyRate);

			var parklots = new List<Parklot> ();
			parklots.Add (park1);
			parklots.Add (park2);
			var parkBoy = new SuperBoy ();
			parkBoy.AddParkLot (parklots);

			parkBoy.ParkIn (myCar);

			Assert.True (park1.TakeOut("MyCar").Equals(myCar));
		}
	}
}

