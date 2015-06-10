using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class ParkManager:ParkingBase,IPrintable
	{
		private List<ParkingBase> boys = new List<ParkingBase> ();

		private List<IPrintable> printableList
		{
			get{
				var list = new List<IPrintable> ();
				list.AddRange (parklots);
				list.AddRange (boys);
				return list;
			}
		}

		public ParkManager ()
		{
			base.CompareFunc = (x, y) => x.Capacity - 0;
		}

		public override bool ParkIn (Car car)
		{
			bool success = false;
			if (boys.Count > 0) {
				success =	boys [0].ParkIn (car);
			}
			if (success)
				return success;
			else
				return base.ParkIn (car);
		}

		public override Car TakeOut (string id)
		{
			Car car = new Car ("UnKnown");
			if (boys.Count > 0) {
				car = boys [0].TakeOut (id);
			}
			if (car.Id.Equals(id))
				return car;
			else
				return base.TakeOut (id);
		}

		public void AddParkBoy (ParkingBase boy)
		{
			boys.Add (boy);
		}

		public override string Print (string prefix)
		{
			string result = GetParkNum ();
			 
			foreach (var item in printableList) {
				result += "\n" + item.Print ("\t");
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

