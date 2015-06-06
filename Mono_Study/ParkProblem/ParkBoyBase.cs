using System;
using System.Collections.Generic;
using System.Collections;

namespace ParkProblem
{
	public abstract class ParkBoyBase
	{
		protected List<Parklot> parklots = new List<Parklot>();

		protected Func<Parklot,Parklot,int> CompareFunc = (x, y) => x.Capacity - 0; // Default compare returen a not empty parklot.

		public virtual Car TakeOut(string id)
		{  
			return this.parklots.Find(x=>x.ContainsCar(id)).TakeOut (id);
		}

		public virtual bool ParkIn(Car car)
		{
			if (parklots.Count == 0)
				return false;

			parklots.Sort (CompareFunc.AsCompare());
			return	parklots [0].ParkIn (car); 
		}
	}
}

