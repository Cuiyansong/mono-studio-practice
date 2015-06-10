using System;

namespace ParkProblem
{
	public interface IPrintable
	{
		string Print (string prefix);

		int CarNum{ get;}

		int Capacity{get;}
	}
}

