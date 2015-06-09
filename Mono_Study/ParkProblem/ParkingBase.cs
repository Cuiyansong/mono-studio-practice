using System;
using System.Collections.Generic;
using System.Collections;

namespace ParkProblem
{
	public abstract class ParkingBase
	{
		#region Property

		/// <summary>
		/// The parklots.
		/// </summary>
		protected List<Parklot> parklots = new List<Parklot> ();
		/// <summary>
		/// Default compare returen a not empty parklot.
		/// </summary>
		protected Func<Parklot,Parklot,int> CompareFunc = (x, y) => x.Capacity - 0;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets the totoal cars.
		/// </summary>
		/// <value>The totoal cars.</value>
		public virtual int TotoalCars {
			get {
				int total = 0;
				foreach (var item in parklots) {
					total += item.CarNum;
				}
				return total;
			}
		}

		/// <summary>
		/// Gets the totoal capacity.
		/// </summary>
		/// <value>The totoal capacity.</value>
		public virtual int TotoalCapacity {
			get {
				int total = 0;
				foreach (var item in parklots) {
					total += item.Capacity;
				}
				return total;
			}
		}

		#endregion

		#region Method

		/// <summary>
		/// Takes the out.
		/// </summary>
		/// <returns>The out.</returns>
		/// <param name="id">Identifier.</param>
		public virtual Car TakeOut (string id)
		{  
			return this.parklots.Find (x => x.ContainsCar (id)).TakeOut (id);
		}

		/// <summary>
		/// Parks the in.
		/// </summary>
		/// <returns><c>true</c>, if in was parked, <c>false</c> otherwise.</returns>
		/// <param name="car">Car.</param>
		public virtual bool ParkIn (Car car)
		{
			if (parklots.Count == 0)
				return false;

			parklots.Sort (CompareFunc.AsCompare ());
			return	parklots [0].ParkIn (car); 
		}

		/// <summary>
		/// Adds the parklots.
		/// </summary>
		/// <param name="parks">Parks.</param>
		public void AddParklots (IEnumerable<Parklot> parks)
		{
			this.parklots.AddRange (parks);
		}


		public virtual string Print (string prefix)
		{
			string result = prefix + GetParkInfoByParklot ();

			foreach (var lot in parklots) {
				result += "\n" + prefix + lot.Print ("\t");
			}
			return result;
		}

		#endregion

		#region Private Method

		/// <summary>
		/// Gets the park info by parklot.
		/// </summary>
		/// <returns>The park info by parklot.</returns>
		private string GetParkInfoByParklot ()
		{
			if (parklots.Count <= 0)
				return "B 0 0";
			else {
				int carNum = 0;
				int capacityNum = 0;

				foreach (var parklot in parklots) {
					carNum += parklot.CarNum;
					capacityNum += parklot.Capacity;
				}

				return string.Format ("B {0} {1}", capacityNum - carNum, capacityNum);
			}
		}

		#endregion

	}
}

