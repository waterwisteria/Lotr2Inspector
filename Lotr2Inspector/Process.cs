using System;

namespace Lotr2Inspector
{
	/**
	 * Lords2 instance class
	 * 
	 */
	public class Process
	{
		public const int LORDS2_BASE_ADDRESS = 0x400000;
		public const String LORDS2_PROCESS_NAME = "Lords2";

		public const int LORDS2_PROCESS_VM_READ = 0x0010;
		public const int LORDS2_PROCESS_VM_WRITE = 0x0020;
		public const int LORDS2_PROCESS_VM_OPERATION = 0x0008;
		public const int LORDS2_PROCESS_ALL_ACCESS = 0x1F0FFF;

		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
	}
}
