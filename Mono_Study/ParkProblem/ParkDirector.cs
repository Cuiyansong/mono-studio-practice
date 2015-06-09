using System;

namespace ParkProblem
{
	public class ParkDirector
	{
		private ParkManager manager;

		public ParkDirector (ParkManager manager)
		{
			this.manager = manager;
		}

		public string Print()
		{
			return manager.Print ("");
		}
	}
}

