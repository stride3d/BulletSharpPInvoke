using Xenko.Core.Mathematics;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BulletSharp
{
	public class bFile
	{
		internal IntPtr _native;

		internal bFile(IntPtr native)
		{
			_native = native;
		}
        /*
		public void AddDataBlock(char dataBlock)
		{
			bFile_addDataBlock(_native, dataBlock._native);
		}

		public void DumpChunks(bDNA dna)
		{
			bFile_dumpChunks(_native, dna._native);
		}
        */
		public IntPtr FindLibPointer(IntPtr ptr)
		{
			return bFile_findLibPointer(_native, ptr);
		}

		public bool Ok()
		{
			return bFile_ok(_native);
		}

		public void Parse(int verboseMode)
		{
			bFile_parse(_native, verboseMode);
		}

		public void PreSwap()
		{
			bFile_preSwap(_native);
		}

		public void ResolvePointers(int verboseMode)
		{
			bFile_resolvePointers(_native, verboseMode);
		}

		public void UpdateOldPointers()
		{
			bFile_updateOldPointers(_native);
		}
        /*
		public int Write(char fileName, bool fixupPointers)
		{
			return bFile_write(_native, fileName._native, fixupPointers);
		}

		public int Write(char fileName)
		{
			return bFile_write2(_native, fileName._native);
		}

		public void WriteChunks(FILE fp, bool fixupPointers)
		{
			bFile_writeChunks(_native, fp._native, fixupPointers);
		}

		public void WriteDNA(FILE fp)
		{
			bFile_writeDNA(_native, fp._native);
		}

		public void WriteFile(char fileName)
		{
			bFile_writeFile(_native, fileName._native);
		}

		public bDNA FileDNA
		{
			get { return bFile_getFileDNA(_native); }
		}
        */
		public int Flags
		{
			get { return bFile_getFlags(_native); }
		}
        /*
		public bPtrMap LibPointers
		{
			get { return bFile_getLibPointers(_native); }
		}
        */
		public int Version
		{
			get { return bFile_getVersion(_native); }
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				bFile_delete(_native);
				_native = IntPtr.Zero;
			}
		}

		~bFile()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_addDataBlock(IntPtr obj, IntPtr dataBlock);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_dumpChunks(IntPtr obj, IntPtr dna);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr bFile_findLibPointer(IntPtr obj, IntPtr ptr);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr bFile_getFileDNA(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int bFile_getFlags(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr bFile_getLibPointers(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int bFile_getVersion(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern bool bFile_ok(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_parse(IntPtr obj, int verboseMode);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_preSwap(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_resolvePointers(IntPtr obj, int verboseMode);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_updateOldPointers(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int bFile_write(IntPtr obj, IntPtr fileName, bool fixupPointers);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int bFile_write2(IntPtr obj, IntPtr fileName);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_writeChunks(IntPtr obj, IntPtr fp, bool fixupPointers);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_writeDNA(IntPtr obj, IntPtr fp);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_writeFile(IntPtr obj, IntPtr fileName);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void bFile_delete(IntPtr obj);
	}
}
