using System;

namespace AirConsole.iOS
{
	public partial class AirconsoleSession
	{
		static unsafe nuint ReadWrite (byte [] buffer, Func<IntPtr, nuint, nuint> handler)
		{	
			if (buffer == null)
				throw new ArgumentNullException (nameof (buffer));

			if (buffer.Length == 0)
				return 0;

			fixed (byte *ptr = &buffer [0])
				return handler (new IntPtr (ptr), (nuint)buffer.Length);
		}

		public unsafe nuint Read (byte [] buffer)
		{
			return ReadWrite (buffer, Read);
		}

		public unsafe nuint Write (byte [] buffer)
		{
			return ReadWrite (buffer, Write);
		}
	}
}
