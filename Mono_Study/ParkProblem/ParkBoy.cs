using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class ParkBoy: ParkingBase
	{
		public ParkBoy()
		{
			base.CompareFunc = (x, y) => x.Capacity - 0;
		}
	}
}