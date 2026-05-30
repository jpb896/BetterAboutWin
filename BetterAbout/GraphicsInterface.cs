using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace BetterAbout
{
    public class GraphicsInterface
    {
        public static string GetGPUName() 
        {
            string name = "Information could not be found";
            using var searcher = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject obj in searcher.Get().Cast<ManagementObject>())
            {
                name = (string)obj["Name"];
            }
            return name;
        }
    }
}
