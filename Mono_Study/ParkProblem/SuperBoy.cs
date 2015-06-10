using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class SuperBoy: ParkingBase
	{
		public SuperBoy()
		{
			this.CompareFunc = (x, y) => x.VacancyRate - y.VacancyRate > 0 ? -1: 1;
		}
	}
}