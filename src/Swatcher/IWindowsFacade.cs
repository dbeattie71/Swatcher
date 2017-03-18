using System;
using System.Runtime.InteropServices;
using System.Threading;
using BraveLantern.Swatcher.Native;
using Microsoft.Win32.SafeHandles;

namespace BraveLantern.Swatcher
{
    internal interface IWindowsFacade
    {
        IntPtr CreateIoCompletionPort(
            SafeFileHandle fileHandle,
            SafeLocalMemHandle existingCompletionPort,
            uint completionKey,
            uint numberOfConcurrentThreads);

        unsafe bool ReadDirectoryChangesW(
            SafeFileHandle hDirectory,
            HandleRef lpBuffer,
            int nBufferLength,
            int bWatchSubtree,
            int dwNotifyFilter,
            int lpBytesReturned,
            NativeOverlapped* overlappedPointer,
            SafeLocalMemHandle lpCompletionRoutine);

        SafeFileHandle CreateFile(
            string lpFileName,
            int dwDesiredAccess,
            int dwShareMode,
            SecurityAttributes lpSecurityAttributes,
            int dwCreationDisposition,
            int dwFlagsAndAttributes,
            SafeFileHandle hTemplateFile);

        uint GetLastError();

        unsafe bool GetQueuedCompletionStatus(
            SafeLocalMemHandle completionPort,
            out uint ptrBytesTransferred,
            out uint ptrCompletionKey,
            NativeOverlapped** lpOverlapped,
            uint milliseconds);

        unsafe bool GetQueuedCompletionStatusEx(
            SafeLocalMemHandle completionPort,
            NativeOverlapped** lpOverlapped,
            ulong itemCount,
            out ulong entriesRemoved,
            uint milliseconds,
            bool alertable);

        unsafe bool PostQueuedCompletionStatus(
            SafeLocalMemHandle completionPort,
            uint ptrBytesTransferred,
            uint ptrCompletionKey,
            NativeOverlapped* lpOverlapped);
    }
}