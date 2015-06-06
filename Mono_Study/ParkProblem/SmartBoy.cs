using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class SmartBoy: ParkingBase
	{
		public SmartBoy()
		{
			base.CompareFunc = (x, y) => x.Capacity - y.Capacity;
		}

		public SmartBoy(List<Parklot> parklots): this()
		{
			this.parklots.AddRange(parklots);
		}

		public SmartBoy(Parklot parklot):this()
		{
			this.parklots.Add (parklot);
		}
	}
}

