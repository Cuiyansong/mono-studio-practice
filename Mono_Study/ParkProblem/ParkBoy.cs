using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class ParkBoy: ParkBoyBase
	{
		public ParkBoy()
		{
			base.CompareFunc = (x, y) => x.Capacity - 0;
		}

		public ParkBoy(List<Parklot> parklots): this()
		{
			this.parklots.AddRange(parklots);
		}

		public ParkBoy(Parklot parklot):this()
		{
			this.parklots.Add (parklot);
		}
	}
}