using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class ParkManager:ParkBoyBase
	{
		public ParkManager()
		{
			base.CompareFunc = (x, y) => x.Capacity - 0;
		}

		public ParkManager(List<Parklot> parklots): this()
		{
			this.parklots.AddRange(parklots);
		}

		public ParkManager(Parklot parklot):this()
		{
			this.parklots.Add (parklot);
		}
	}
}

