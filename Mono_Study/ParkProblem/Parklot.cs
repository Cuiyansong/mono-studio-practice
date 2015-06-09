using System;
using System.Collections.Generic;

namespace ParkProblem
{
	public class Parklot:IPrintable
	{
		private List<Car> cars = new List<Car> ();

		public int Capacity { get; private set; }

		public float VacancyRate {
			get { return (this.Capacity - cars.Count) / (float)Capacity; }
		}

		public int CarNum {
			get {
				return cars.Count;
			}
		}

		public string ParklotId{ get; set; }

		public Parklot ()
		{
			this.Capacity = 10;
		}

		public Parklot (int capacity)
		{
			this.Capacity = capacity;
		}

		public bool ContainsCar (string id)
		{
			for (int i = 0; i < cars.Count; i++) {
				if (cars [i].Id.Equals (id)) {
					return true;
				}
			}
			return false;
		}

		public bool ParkIn (Car car)
		{
			if (this.cars.Count >= this.Capacity)
				return false;

			cars.Add (car);
			return true;
		}


		public Car TakeOut (string carId)
		{
			if (!cars.Exists (x => x.Id.Equals (carId))) {
				return null;
			}

			return cars.Find (x => x.Id.Equals (carId));
		}

		public string Print (string prefix)
		{
			return string.Format ("{0}P {1} {2}", prefix, Capacity - cars.Count, Capacity);
		}
	}
}

