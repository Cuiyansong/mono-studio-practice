using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class ParkManager:ParkingBase
	{
		private List<ParkingBase> boys = new List<ParkingBase> ();

		public ParkManager ()
		{
			base.CompareFunc = (x, y) => x.Capacity - 0;
		}

		public ParkManager (List<Parklot> parklots) : this ()
		{
			this.parklots.AddRange (parklots);
		}

		public ParkManager (Parklot parklot) : this ()
		{
			this.parklots.Add (parklot);
		}

		public override bool ParkIn (Car car)
		{
			if (boys.Count > 0) {
				return	boys [0].ParkIn (car);
			}

			return base.ParkIn (car);
		}

		public override Car TakeOut (string id)
		{
			if (boys.Count > 0) {
				return boys [0].TakeOut (id);
			}

			return base.TakeOut (id);
		}

		public void AddParkBoy (ParkingBase boy)
		{
			boy.AddParklots (new Parklot());
			boys.Add (boy);
		}
	}
}

