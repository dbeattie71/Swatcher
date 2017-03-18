using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace BraveLantern.Swatcher.Native
{
    internal sealed class WindowsFacade : IWindowsFacade
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateIoCompletionPort(
            [In] SafeFileHandle fileHandle,
            [In] SafeLocalMemHandle existingCompletionPort,
            [In] UInt32 completionKey,
            [In] UInt32 numberOfConcurrentThreads);


        unsafe bool IWindowsFacade.ReadDirectoryChangesW(
            SafeFileHandle hDirectory, HandleRef lpBuffer, int nBufferLength, int bWatchSubtree,
            int dwNotifyFilter, int lpBytesReturned, NativeOverlapped* overlappedPointer, SafeLocalMemHandle lpCompletionRoutine)
        {
            return ReadDirectoryChangesW(hDirectory, lpBuffer, nBufferLength, bWatchSubtree, dwNotifyFilter, lpBytesReturned, overlappedPointer, lpCompletionRoutine);
        }

        SafeFileHandle IWindowsFacade.CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode,
            SecurityAttributes lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes,
            SafeFileHandle hTemplateFile)
        {
            return CreateFile(lpFileName, dwDesiredAccess, dwShareMode, lpSecurityAttributes, dwCreationDisposition, dwFlagsAndAttributes, hTemplateFile);
        }

        uint IWindowsFacade.GetLastError()
        {
            return GetLastError();
        }

        unsafe bool IWindowsFacade.GetQueuedCompletionStatus(SafeLocalMemHandle completionPort, out uint ptrBytesTransferred, out uint ptrCompletionKey,
            NativeOverlapped** lpOverlapped, uint milliseconds)
        {
            return GetQueuedCompletionStatus(completionPort, out ptrBytesTransferred, out ptrCompletionKey, lpOverlapped, milliseconds);
        }

        unsafe bool IWindowsFacade.GetQueuedCompletionStatusEx(SafeLocalMemHandle completionPort, NativeOverlapped** lpOverlapped, ulong itemCount,
            out ulong entriesRemoved, uint milliseconds, bool alertable)
        {
            return GetQueuedCompletionStatusEx(completionPort, lpOverlapped, itemCount, out entriesRemoved, milliseconds, alertable);
        }

        unsafe bool IWindowsFacade.PostQueuedCompletionStatus(SafeLocalMemHandle completionPort, uint ptrBytesTransferred, uint ptrCompletionKey,
            NativeOverlapped* lpOverlapped)
        {
            return PostQueuedCompletionStatus(completionPort, ptrBytesTransferred, ptrCompletionKey, lpOverlapped);
        }

        IntPtr IWindowsFacade.CreateIoCompletionPort(SafeFileHandle fileHandle, SafeLocalMemHandle existingCompletionPort, uint completionKey,
            uint numberOfConcurrentThreads)
        {
            return CreateIoCompletionPort(fileHandle, existingCompletionPort, completionKey, numberOfConcurrentThreads);
        }

        [DllImport("Kernel32", CharSet = CharSet.Auto)]
        internal static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32", EntryPoint = "ReadDirectoryChangesW", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern unsafe bool ReadDirectoryChangesW(
            [In] SafeFileHandle hDirectory,
            [Out] HandleRef lpBuffer,
            [In] int nBufferLength,
            [In] int bWatchSubtree,
            [In] int dwNotifyFilter,
            [Out] int lpBytesReturned,
            NativeOverlapped* overlappedPointer,
            [In] SafeLocalMemHandle lpCompletionRoutine);

        [DllImport("kernel32", CharSet = CharSet.Auto, BestFitMapping = false, SetLastError = true)]
        internal static extern SafeFileHandle CreateFile(
            [In] string lpFileName,
            [In] int dwDesiredAccess,
            [In] int dwShareMode,
            [In] SecurityAttributes lpSecurityAttributes,
            [In] int dwCreationDisposition,
            [In] int dwFlagsAndAttributes,
            [In] SafeFileHandle hTemplateFile);

        [DllImport("kernel32.dll")]
        internal static extern UInt32 GetLastError();

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern unsafe bool GetQueuedCompletionStatus(
            [In] SafeLocalMemHandle completionPort,
            [Out] out UInt32 ptrBytesTransferred,
            [Out] out UInt32 ptrCompletionKey,
            [Out] NativeOverlapped** lpOverlapped,
            [In] UInt32 milliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern unsafe bool GetQueuedCompletionStatusEx(
            [In] SafeLocalMemHandle completionPort,
            [Out] NativeOverlapped** lpOverlapped,
            [In] ulong itemCount,
            [Out] out ulong entriesRemoved,
            [In] UInt32 milliseconds,
            [In] bool alertable);

        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern unsafe bool PostQueuedCompletionStatus(
            [In] SafeLocalMemHandle completionPort,
            [In] UInt32 ptrBytesTransferred,
            [In] UInt32 ptrCompletionKey,
            [In] NativeOverlapped* lpOverlapped);


    }
}