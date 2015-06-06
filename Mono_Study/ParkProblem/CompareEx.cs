using System;
using System.Collections.Generic;
using System.Collections;

namespace ParkProblem
{
	public static class CompareEx
	{
		public static IComparer<T> AsCompare<T>(this Func<T,T,int> @this)
		{
			return new ComparisonCompiler<T> ((x, y) => @this (x, y));
		}
	}

	public class ComparisonCompiler<T>: IComparer<T>
	{
		public Comparison<T> Comparison{ get; private set;}

		public ComparisonCompiler(Comparison<T> Compare)
		{
			this.Comparison = Compare;
		}

		#region IComparer implementation
		public int Compare (T x, T y)
		{
			return this.Comparison (x, y);
		}
		#endregion
	}
}

