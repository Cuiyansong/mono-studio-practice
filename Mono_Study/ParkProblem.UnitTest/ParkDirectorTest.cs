using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ParkProblem.UnitTest
{
	[TestFixture ()]
	public class ParkDirectorTest
	{
		[Test ()]
		public void Should_print_log_success_when_manager_have_one_manager ()
		{
			var manager = new ParkManager ();
			var director = new ParkDirector (manager);

			Assert.AreEqual (director.Print (), "M 0 0");
		}

		[Test ()]
		public void Should_print_log_success_when_manager_have_one_parkBoy_and_parkBoy_has_parklot ()
		{
			var park = new Parklot (1);
			var boy = new ParkBoy (park);
			var manager = new ParkManager ();
			manager.AddParkBoy (boy);
			var director = new ParkDirector (manager);

			Assert.AreEqual (director.Print (), "M 1 1\n\tB 1 1\n\t\tP 1 1");
		}

		[Test ()]
		public void Should_print_log_success_when_manager_have_one_parkBoy_and_parkBoy_has_no_parklot ()
		{
			var boy = new ParkBoy ();
			var manager = new ParkManager ();
			manager.AddParkBoy (boy);
			var director = new ParkDirector (manager);
			Console.WriteLine (director.Print ());

			Assert.AreEqual (director.Print (), "M 0 0\n\tB 0 0");
		}

		[Test ()]
		public void Should_print_log_success_when_manager_have_two_parkBoy_and_parkBoy_has_parklot ()
		{
			var park1 = new Parklot (1);
			var park2 = new Parklot (1);
			var boy1 = new ParkBoy (park1);
			var boy2 = new ParkBoy (park2);
			var manager = new ParkManager ();
			manager.AddParkBoy (boy1);
			manager.AddParkBoy (boy2);
			var director = new ParkDirector (manager);

			Assert.AreEqual (director.Print (), "M 2 2\n\tB 1 1\n\t\tP 1 1\n\tB 1 1\n\t\tP 1 1");
		}

		[Test ()]
		public void Should_print_log_success_when_manager_have_two_parkBoy_and_no_parkBoy_has_parklot ()
		{ 
			var boy1 = new ParkBoy ();
			var boy2 = new ParkBoy ();
			var manager = new ParkManager ();
			manager.AddParkBoy (boy1);
			manager.AddParkBoy (boy2);
			var director = new ParkDirector (manager);

			Assert.AreEqual (director.Print (), "M 0 0\n\tB 0 0\n\tB 0 0");
		}

		[Test ()]
		public void Should_print_log_success_when_manager_have_no_parkBoy_and_have_one_parklot ()
		{ 
			var park = new Parklot (1);
			var manager = new ParkManager (park);
			var director = new ParkDirector (manager);

			Assert.AreEqual (director.Print (), "M 1 1\n\tP 1 1");
		}

		[Test ()]
		public void Should_print_log_success_when_manager_have_no_parkBoy_and_have_two_parklot ()
		{ 
			var park1 = new Parklot (1);
			var park2 = new Parklot (1);
			var manager = new ParkManager (new List<Parklot>{ park1, park2 });
			var director = new ParkDirector (manager);

			Assert.AreEqual (director.Print (), "M 2 2\n\tP 1 1\n\tP 1 1");
		}

		[Test ()]
		public void Should_print_log_success_when_manager_have_one_parkBoy_and_have_one_parklot ()
		{ 
			var park1 = new Parklot (1);
			var park2 = new Parklot (1);
			var boy = new ParkBoy (park2);
			var manager = new ParkManager (new List<Parklot>{ park1 });
			manager.AddParkBoy (boy);
			var director = new ParkDirector (manager);

			Assert.AreEqual (director.Print (), "M 2 2\n\tP 1 1\n\tB 1 1\n\t\tP 1 1");
		}

		[Test ()]
		public void Should_print_log_success_when_manager_have_one_parklot_and_have_two_parkboys ()
		{ 
			var park1 = new Parklot (10);
			for (int i = 0; i < 8; i++) {
				park1.ParkIn (new Car (i.ToString ()));
			}
			var park2 = new Parklot (5);
			for (int i = 0; i < 3; i++) {
				park2.ParkIn (new Car (i.ToString ()));
			}
			var boy1 = new ParkBoy (park2);
			var park3 = new Parklot (3);
			for (int i = 0; i < 3; i++) {
				park3.ParkIn (new Car ("b"));
			}
			var park4 = new Parklot (2);
			park4.ParkIn (new Car ("a"));
			var boy2 = new ParkBoy (new List<Parklot>{ park3, park4 });

			var manager = new ParkManager (new List<Parklot>{ park1 });
			manager.AddParkBoy (boy1);
			manager.AddParkBoy (boy2);
			var director = new ParkDirector (manager);

			Console.WriteLine (director.Print ());
			Assert.AreEqual (director.Print (), "M 5 20\n\tP 2 10\n\tB 2 5\n\t\tP 2 5\n\tB 1 5\n\t\tP 0 3\n\t\tP 1 2");
		}
	}
}

