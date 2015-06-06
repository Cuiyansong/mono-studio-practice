using System;

namespace Mono_Study
{
	public class Things
	{
		private int _length = 0;

		public Things (int length)
		{
			this._length = length;	
		}

		public override bool Equals (object obj)
		{
			return this._length == (obj as Things)._length;
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}
	}
}

