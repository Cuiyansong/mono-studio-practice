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
	}
}

