using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher
{
    internal static class FileSystemConstants
    {
        public const int FileReadData = (0x0001);

        public const int FileListDirectory = (0x0001);

        public const int FileWriteData = (0x0002);

        public const int FileAddFile = (0x0002);

        public const int FileAppendData = (0x0004);

        public const int FileAddSubdirectory = (0x0004);

        public const int FileCreatePipeInstance = (0x0004);

        public const int FileReadEa = (0x0008);

        public const int FileWriteEa = (0x0010);

        public const int FileExecute = (0x0020);

        public const int FileTraverse = (0x0020);

        public const int FileDeleteChild = (0x0040);

        public const int FileReadAttributes = (0x0080);

        public const int FileWriteAttributes = (0x0100);

        public const int FileShareRead = 0x00000001;

        public const int FileShareWrite = 0x00000002;

        public const int FileShareDelete = 0x00000004;

        public const int FileAttributeReadonly = 0x00000001;

        public const int FileAttributeHidden = 0x00000002;

        public const int FileAttributeSystem = 0x00000004;

        public const int FileAttributeDirectory = 0x00000010;

        public const int FileAttributeArchive = 0x00000020;

        public const int FileAttributeNormal = 0x00000080;

        public const int FileAttributeTemporary = 0x00000100;

        public const int FileAttributeCompressed = 0x00000800;

        public const int FileAttributeOffline = 0x00001000;

        public const int FileNotifyChangeFileName = 0x00000001;

        public const int FileNotifyChangeDirName = 0x00000002;

        public const int FileNotifyChangeAttributes = 0x00000004;

        public const int FileNotifyChangeSize = 0x00000008;

        public const int FileNotifyChangeLastWrite = 0x00000010;

        public const int FileNotifyChangeLastAccess = 0x00000020;

        public const int FileNotifyChangeCreation = 0x00000040;

        public const int FileNotifyChangeSecurity = 0x00000100;

        public const int FileActionAdded = 0x00000001;

        public const int FileActionRemoved = 0x00000002;

        public const int FileActionModified = 0x00000003;

        public const int FileActionRenamedOldName = 0x00000004;

        public const int FileActionRenamedNewName = 0x00000005;

        public const int FileCaseSensitiveSearch = 0x00000001;

        public const int FileCasePreservedNames = 0x00000002;

        public const int FileUnicodeOnDisk = 0x00000004;

        public const int FilePersistentAcls = 0x00000008;

        public const int FileFileCompression = 0x00000010;

        public const int OpenExisting = 3;

        public const int OpenAlways = 4;

        public const int FileFlagWriteThrough = unchecked((int)0x80000000);

        public const int FileFlagOverlapped = 0x40000000;

        public const int FileFlagNoBuffering = 0x20000000;

        public const int FileFlagRandomAccess = 0x10000000;

        public const int FileFlagSequentialScan = 0x08000000;

        public const int FileFlagDeleteOnClose = 0x04000000;

        public const int FileFlagBackupSemantics = 0x02000000;

        public const int FileFlagPosixSemantics = 0x01000000;

        public const int FileTypeUnknown = 0x0000;

        public const int FileTypeDisk = 0x0001;

        public const int FileTypeChar = 0x0002;

        public const int FileTypePipe = 0x0003;

        public const int FileTypeRemote = 0x8000;

        public const int FileVolumeIsCompressed = 0x00008000;
    }
}
