using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BetterAbout
{
    public class StorageInterface
    {
        public static string GetTotalSize()
        {
            DriveInfo driveInfo = new(Directory.GetDirectoryRoot("C:\\Windows"));
            long totalSize = driveInfo.TotalSize / 1000000000;
            return totalSize + "GB";
        }
    }
}
