using System;

namespace Mono_Study
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Test begin....");

			var t1 = new Things (10);
			var t2 = new Things (12);
			Console.WriteLine (t1.Equals (t2));

			Console.Read ();
		}
	}
}
