using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class ParkManager:ParkingBase,IPrintable
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
			boys.Add (boy);
		}

		public override string Print (string prefix)
		{
			string result = GetParkNum ();

			foreach (IPrintable lot in parklots) {
				result += "\n" + lot.Print ("\t");
			}
			
			foreach (IPrintable boy in boys) {
				result += "\n" + boy.Print ("\t");
			}

			return result;
		}

		#region Private Method

		private string GetParkNum ()
		{
			if (boys.Count <= 0 && parklots.Count <= 0)
				return "M 0 0";
			else {
				int carNum = 0;
				int capacityNum = 0;

				foreach (var lot in parklots) {
					carNum += lot.CarNum;
					capacityNum += lot.Capacity;
				}

				foreach (var boy in boys) {
					carNum += boy.TotoalCars;
					capacityNum += boy.TotoalCapacity;
				}

				return string.Format ("M {0} {1}", capacityNum - carNum, capacityNum);
			}
		}

		#endregion
	}
}

