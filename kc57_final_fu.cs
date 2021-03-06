using System;
using System.Runtime.InteropServices;
using System.Text;
using SJITHook.Compact;

namespace kc57_final_fu
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x06000002 RID: 2
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, Program.AllocationType lAllocationType, Program.MemoryProtection flProtect);

		// Token: 0x06000003 RID: 3 RVA: 0x00002050 File Offset: 0x00000250
		static Program()
		{
			Program.hook.Hook(new Data.CompileMethodDel(Program.HookedCompileMethod));
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002074 File Offset: 0x00000274
		~Program()
		{
			Program.hook.UnHook();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020A8 File Offset: 0x000002A8
		private static void Main(string[] args)
		{
			Console.Write("Gimme dat password: ");
			string password = Console.ReadLine();
			string str = Program.get_flag(password);
			Console.WriteLine("flag: " + str);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020E0 File Offset: 0x000002E0
		private static string printByteArray(byte[] data)
		{
			StringBuilder stringBuilder = new StringBuilder(data.Length * 2);
			foreach (byte b in data)
			{
				stringBuilder.AppendFormat("0x{0:x2}, ", b);
			}
			return stringBuilder.ToString().Remove(stringBuilder.Length - 2, 2);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002140 File Offset: 0x00000340
		private static string get_flag(string password)
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000024B4 File Offset: 0x000006B4
		private unsafe static int HookedCompileMethod(IntPtr thisPtr, [In] IntPtr corJitInfo, [In] Data.CorMethodInfo* methodInfo, Data.CorJitFlag flags, [Out] IntPtr nativeEntry, [Out] IntPtr nativeSizeOfCode)
		{
			byte[] key = new byte[]
			{
				75,
				99,
				53,
				55,
				75,
				99,
				53,
				55,
				75,
				99,
				53,
				55,
				75,
				99,
				53,
				55
			};
			byte[] iv = new byte[]
			{
				68,
				101,
				114,
				98,
				121,
				67,
				84,
				70,
				68,
				101,
				114,
				98,
				121,
				67,
				84,
				70
			};
			bool flag = *(ushort*)((void*)methodInfo->methodHandle) == 0;
			int result;
			if (flag)
			{
				result = Program.hook.OriginalCompileMethod(thisPtr, corJitInfo, methodInfo, flags, nativeEntry, nativeSizeOfCode);
			}
			else
			{
				int metadataToken = 100663296 + (int)(*(ushort*)((void*)methodInfo->methodHandle));
				string name = typeof(Program).Module.ResolveMethod(metadataToken).Name;
				byte[] array = new byte[methodInfo->ilCodeSize];
				Marshal.Copy(methodInfo->ilCode, array, 0, array.Length);
				StringBuilder stringBuilder = new StringBuilder(array.Length * 2);
				foreach (byte b in array)
				{
					stringBuilder.AppendFormat("0x{0:x2}, ", b);
				}
				string text = stringBuilder.ToString().Remove(stringBuilder.Length - 2, 2);
				bool flag2 = name == "get_flag";
				if (flag2)
				{
					byte[] cipherText = new byte[]
					{
						143,
						73,
						219,
						254,
						44,
						206,
						117,
						203,
						242,
						104,
						86,
						134,
						170,
						254,
						173,
						41,
						125,
						182,
						118,
						230,
						43,
						158,
						134,
						239,
						163,
						200,
						100,
						161,
						10,
						183,
						233,
						115,
						35,
						182,
						113,
						199,
						170,
						137,
						122,
						241,
						184,
						139,
						160,
						26,
						11,
						127,
						118,
						111,
						208,
						246,
						208,
						232,
						72,
						239,
						107,
						19,
						192,
						194,
						187,
						16,
						12,
						28,
						197,
						153,
						215,
						53,
						52,
						46,
						37,
						61,
						34,
						248,
						166,
						49,
						222,
						241,
						30,
						243,
						90,
						230,
						181,
						227,
						51,
						154,
						185,
						49,
						252,
						192,
						153,
						16,
						10,
						232,
						223,
						152,
						78,
						38,
						245,
						101,
						217,
						165,
						199,
						125,
						197,
						182,
						3,
						15,
						252,
						73,
						104,
						112,
						115,
						82,
						254,
						4,
						124,
						164,
						192,
						31,
						36,
						75,
						199,
						174,
						34,
						176,
						187,
						151,
						170,
						138,
						32,
						170,
						91,
						232,
						213,
						119,
						175,
						18,
						0,
						84,
						80,
						108,
						34,
						67,
						105,
						63,
						4,
						51,
						125,
						140,
						165,
						179,
						174,
						249,
						229,
						15,
						50,
						22,
						159,
						129,
						76,
						116,
						55,
						176,
						159,
						1,
						71,
						247,
						56,
						85,
						234,
						101,
						239,
						249,
						48,
						186,
						208,
						74,
						50,
						250,
						7,
						205,
						129,
						120,
						106,
						221,
						182,
						43,
						43,
						38,
						150,
						40,
						182,
						230,
						48,
						87,
						244,
						141,
						95,
						82,
						193,
						231,
						21,
						242,
						230,
						153,
						25,
						47,
						106,
						133,
						169,
						194,
						242,
						56,
						154,
						245,
						223,
						228,
						75,
						145,
						138,
						82,
						86,
						191,
						134,
						95,
						28,
						175,
						170,
						58,
						201,
						196,
						77,
						66,
						15,
						184,
						165,
						49,
						70,
						199,
						125,
						78,
						87,
						190,
						79,
						215,
						70,
						44,
						26,
						228,
						166,
						186,
						58,
						201,
						102,
						224,
						170,
						27,
						81,
						102,
						72,
						30,
						155,
						214,
						172,
						243,
						118,
						27,
						175,
						19,
						147,
						52,
						166,
						33,
						153,
						124,
						72,
						249,
						85,
						168,
						80,
						140,
						21,
						138,
						250,
						226,
						162,
						23,
						17,
						70,
						0,
						140,
						160,
						97,
						9,
						110,
						89,
						252,
						74,
						102,
						1,
						210,
						15,
						72,
						73,
						91,
						54,
						8,
						151,
						199,
						212,
						3,
						204,
						184,
						11,
						207,
						14,
						24,
						202,
						201,
						84,
						88,
						77,
						249,
						176,
						161,
						195,
						254,
						250,
						65,
						46,
						132,
						40,
						80,
						119,
						98,
						117,
						179,
						170,
						11,
						27,
						159,
						37,
						182,
						110,
						190,
						197,
						78,
						107,
						121,
						233,
						156,
						72,
						44,
						178,
						45,
						140,
						173,
						216,
						53,
						187,
						48,
						53,
						162,
						79,
						146,
						52,
						66,
						202,
						180,
						104,
						18,
						251,
						148,
						117,
						99,
						197,
						205,
						160,
						214,
						243,
						89,
						203,
						122,
						79,
						28,
						239,
						112,
						236,
						110,
						159,
						82,
						60,
						190,
						89,
						3,
						244,
						152,
						246,
						188,
						231,
						8,
						114,
						50,
						11,
						73,
						138,
						178,
						175,
						48,
						156,
						143,
						150,
						230,
						193,
						218,
						244,
						13,
						199,
						107,
						151,
						161,
						99,
						209,
						90,
						72,
						72,
						12,
						67,
						97,
						133,
						84,
						108,
						48,
						57,
						126,
						66,
						63,
						101,
						18,
						24,
						149,
						97,
						162,
						141,
						177,
						22,
						191,
						11,
						147,
						94,
						167,
						158,
						209,
						233,
						83,
						164,
						44,
						44,
						17,
						2,
						207,
						239,
						185,
						230,
						68,
						191,
						0,
						58,
						221,
						0,
						97,
						12,
						128,
						96,
						126,
						241,
						252,
						185,
						128,
						199,
						243,
						65,
						167,
						252,
						134,
						161,
						123,
						35,
						119,
						31,
						227,
						244,
						46,
						219,
						5,
						106,
						84,
						143,
						58,
						75,
						130,
						59,
						98,
						21,
						207,
						254,
						250,
						199,
						239,
						77,
						2,
						95,
						226,
						67,
						106,
						81,
						107,
						39,
						136,
						99,
						136,
						51,
						192,
						113,
						137,
						238,
						209,
						120,
						97,
						147,
						122,
						201,
						248,
						116,
						byte.MaxValue,
						9,
						40,
						167,
						174,
						211,
						42,
						0,
						223,
						30,
						29,
						169,
						165,
						24,
						214,
						29,
						196,
						129,
						37,
						225,
						96,
						167,
						193,
						67,
						212,
						234,
						100,
						61,
						45,
						117,
						3,
						151,
						212,
						187,
						1,
						172,
						69,
						119,
						215,
						201,
						132,
						197,
						235,
						171,
						173,
						32,
						167,
						65,
						91,
						183,
						208,
						23,
						96,
						42,
						29,
						62,
						102,
						91,
						23,
						146,
						102,
						114,
						139,
						15,
						194,
						8,
						210,
						73,
						61,
						111,
						86,
						155,
						111,
						100,
						242,
						60,
						242,
						64,
						70,
						3,
						189,
						27,
						35,
						190,
						85,
						249,
						74,
						81,
						181,
						51,
						byte.MaxValue,
						43,
						183,
						174,
						226,
						75,
						195,
						238,
						165,
						237,
						0,
						24,
						120,
						27,
						65,
						104,
						69,
						126,
						8,
						157,
						4,
						21,
						85,
						190,
						229,
						147,
						163,
						81,
						246,
						89,
						192,
						44,
						176,
						251,
						108,
						224,
						113,
						180,
						16,
						160,
						102,
						205,
						38,
						136,
						175,
						184,
						232,
						185,
						2,
						82,
						229,
						164,
						163,
						48,
						219,
						223,
						19,
						201,
						180,
						8,
						43,
						39,
						132,
						127,
						216,
						58,
						110,
						8,
						250,
						228,
						39,
						50,
						176,
						59,
						128,
						161,
						156,
						252,
						189,
						139,
						93,
						37,
						36,
						135,
						42,
						119,
						13,
						1,
						190,
						233,
						219,
						96,
						210,
						0,
						57,
						10,
						203,
						211,
						67,
						203,
						169,
						133,
						63,
						216,
						130,
						19,
						128,
						39,
						136,
						17,
						41,
						43,
						250,
						155,
						5,
						109,
						177,
						136,
						222,
						145,
						84,
						63,
						69,
						221,
						201,
						41,
						56,
						86,
						16,
						59,
						246,
						23,
						156,
						124,
						141,
						96,
						40,
						207,
						44,
						7,
						174,
						160,
						46,
						55,
						36,
						15,
						138,
						152,
						169,
						127,
						172,
						211,
						208,
						213,
						54,
						115,
						126,
						243,
						165,
						165,
						215,
						102,
						149,
						byte.MaxValue,
						106,
						80,
						254,
						187,
						233,
						164,
						230,
						19,
						65,
						89,
						33,
						5,
						60,
						105,
						238,
						214,
						185,
						205,
						189,
						245,
						236,
						120,
						144,
						101,
						203,
						1,
						151,
						150,
						86,
						230,
						208,
						211,
						160,
						9,
						173,
						103,
						31,
						79,
						151,
						37,
						55,
						37,
						115,
						15,
						14,
						175,
						101,
						122,
						216,
						77,
						212,
						195,
						141,
						13,
						46,
						224,
						83,
						221,
						16,
						73,
						75,
						243,
						78,
						183,
						170,
						171,
						187,
						22,
						185,
						232,
						28,
						50,
						158,
						176,
						26,
						179,
						153,
						250,
						87,
						85,
						108,
						36,
						63,
						69,
						249,
						185,
						51,
						152,
						160,
						70,
						239,
						125,
						16
					};
					byte[] array3 = Utils.Decrypt(cipherText, key, iv);
					uint flNewProtect;
					Program.VirtualProtect(methodInfo->ilCode, methodInfo->ilCodeSize, 64u, out flNewProtect);
					Marshal.Copy(array3, 0, methodInfo->ilCode, array3.Length);
					Program.VirtualProtect(methodInfo->ilCode, methodInfo->ilCodeSize, flNewProtect, out flNewProtect);
				}
				result = Program.hook.OriginalCompileMethod(thisPtr, corJitInfo, methodInfo, flags, nativeEntry, nativeSizeOfCode);
			}
			return result;
		}

		// Token: 0x04000001 RID: 1
		private static JITHook<ClrjitAddrProvider> hook = new JITHook<ClrjitAddrProvider>();

		// Token: 0x0200000A RID: 10
		public enum PageProtection : uint
		{
			// Token: 0x04000008 RID: 8
			PAGE_NOACCESS = 1u,
			// Token: 0x04000009 RID: 9
			PAGE_READONLY,
			// Token: 0x0400000A RID: 10
			PAGE_READWRITE = 4u,
			// Token: 0x0400000B RID: 11
			PAGE_WRITECOPY = 8u,
			// Token: 0x0400000C RID: 12
			PAGE_EXECUTE = 16u,
			// Token: 0x0400000D RID: 13
			PAGE_EXECUTE_READ = 32u,
			// Token: 0x0400000E RID: 14
			PAGE_EXECUTE_READWRITE = 64u,
			// Token: 0x0400000F RID: 15
			PAGE_EXECUTE_WRITECOPY = 128u,
			// Token: 0x04000010 RID: 16
			PAGE_GUARD = 256u,
			// Token: 0x04000011 RID: 17
			PAGE_NOCACHE = 512u,
			// Token: 0x04000012 RID: 18
			PAGE_WRITECOMBINE = 1024u
		}

		// Token: 0x0200000B RID: 11
		public enum MemoryProtection
		{
			// Token: 0x04000014 RID: 20
			Execute = 16,
			// Token: 0x04000015 RID: 21
			ExecuteRead = 32,
			// Token: 0x04000016 RID: 22
			ExecuteReadWrite = 64,
			// Token: 0x04000017 RID: 23
			ExecuteWriteCopy = 128,
			// Token: 0x04000018 RID: 24
			NoAccess = 1,
			// Token: 0x04000019 RID: 25
			ReadOnly,
			// Token: 0x0400001A RID: 26
			ReadWrite = 4,
			// Token: 0x0400001B RID: 27
			WriteCopy = 8,
			// Token: 0x0400001C RID: 28
			GuardModifierflag = 256,
			// Token: 0x0400001D RID: 29
			NoCacheModifierflag = 512,
			// Token: 0x0400001E RID: 30
			WriteCombineModifierflag = 1024
		}

		// Token: 0x0200000C RID: 12
		public enum AllocationType
		{
			// Token: 0x04000020 RID: 32
			Commit = 4096,
			// Token: 0x04000021 RID: 33
			Reserve = 8192,
			// Token: 0x04000022 RID: 34
			Decommit = 16384,
			// Token: 0x04000023 RID: 35
			Release = 32768,
			// Token: 0x04000024 RID: 36
			Reset = 524288,
			// Token: 0x04000025 RID: 37
			Physical = 4194304,
			// Token: 0x04000026 RID: 38
			TopDown = 1048576,
			// Token: 0x04000027 RID: 39
			WriteWatch = 2097152,
			// Token: 0x04000028 RID: 40
			LargePages = 536870912
		}
	}
}
