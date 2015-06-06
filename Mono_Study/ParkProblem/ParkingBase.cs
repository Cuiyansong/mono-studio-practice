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
		#endregion

	}
}

