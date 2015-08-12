using System;

namespace AirConsole.iOS
{
	public enum stopbits_t : uint
	{
		AcStopbits1 = 1,
		AcStopbits2 = 2,
		AcStopbits15 = 3
	}

	public enum flowcontrol_t : uint
	{
		None = 0,
		Software = 1,
		Hardware = 2,
		HardwareDsr = 3
	}

	public enum parity_t : uint
	{
		None = 0,
		Odd = 1,
		Even = 2,
		Mark = 3,
		Space = 4
	}

	public enum databits_t : uint
	{
		AcDatabits7 = 7,
		AcDatabits8 = 8
	}

	public enum AcMsr : uint
	{
		Cts = 16,
		Dsr = 32,
		Ri = 64,
		Dcd = 128
	}

	public enum transport_t : uint
	{
		Any = 0,
		Ip = 1,
		Ble = 2
	}
}
