using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class SuperBoy: ParkBoyBase
	{
		public SuperBoy()
		{
			this.CompareFunc = (x, y) => x.VacancyRate - y.VacancyRate > 0 ? 1: -1;
		}

		public SuperBoy(List<Parklot> parklots)
		{
			this.parklots.AddRange(parklots);
		}

		public SuperBoy(Parklot parklot)
		{
			this.parklots.Add (parklot);
		}
	}
}