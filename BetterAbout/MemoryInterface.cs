using System;
using System.Linq;
using System.Management;

namespace BetterAbout
{
    public class MemoryInterface
    {
        public static string RamType
        {
            get
            {
                int type = 0;

                ConnectionOptions connection = new()
                {
                    Impersonation = ImpersonationLevel.Impersonate
                };
                ManagementScope scope = new("\\\\.\\root\\CIMV2", connection);
                scope.Connect();
                ObjectQuery query = new("SELECT * FROM Win32_PhysicalMemory");
                ManagementObjectSearcher searcher = new(scope, query);
                foreach (ManagementObject queryObj in searcher.Get().Cast<ManagementObject>())
                {
                    type = Convert.ToInt32(queryObj["MemoryType"]);
                }

                return TypeString(type);
            }
        }

        private static string TypeString(int type)
        {
            string outValue = type switch
            {
                0x0 => "Unknown",
                0x1 => "Other",
                0x2 => "DRAM",
                0x3 => "Synchronous DRAM",
                0x4 => "Cache DRAM",
                0x5 => "EDO",
                0x6 => "EDRAM",
                0x7 => "VRAM",
                0x8 => "SRAM",
                0x9 => "RAM",
                0xa => "ROM",
                0xb => "Flash",
                0xc => "EEPROM",
                0xd => "FEPROM",
                0xe => "EPROM",
                0xf => "CDRAM",
                0x10 => "3DRAM",
                0x11 => "SDRAM",
                0x12 => "SGRAM",
                0x13 => "RDRAM",
                0x14 => "DDR",
                0x15 => "DDR2",
                0x16 => "DDR2 FB-DIMM",
                0x17 => "Undefined 23",
                0x18 => "DDR3",
                0x19 => "FBD2",
                0x20 => "DDR4",
                _ => "Undefined",
            };
            return outValue;
        }

        public static string GetRAMAmount()
        {

            ObjectQuery objectQuery = new("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(objectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            var amount = "";
            foreach (ManagementObject managementObject in managementObjectCollection.Cast<ManagementObject>())
            {
                var MemorySize = (UInt64)managementObject["TotalVisibleMemorySize"] / 1000000;
                amount = $"{MemorySize}GB RAM";
            }
            return amount;
        }
    }
}