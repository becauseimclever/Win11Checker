using System;
using System.Linq;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Win11Checker.Models;

namespace Win11Checker
{
    [Cmdlet(VerbsCommon.Get, "Win11Compatibility")]
    [OutputType(typeof(CompatibilityReport))]
    public class Win11Checker : Cmdlet
    {
        protected override async void ProcessRecord()
        {
           

#pragma warning disable CA1416 // Validate platform compatibility
            SelectQuery selectQuery = new("Win32_Processor");
#pragma warning restore CA1416 // Validate platform compatibility
            ManagementObjectSearcher managementObjectSearcher = new(selectQuery);
#pragma warning disable CA1416 // Validate platform compatibility
            ManagementObjectCollection managementObjects = managementObjectSearcher.Get();
#pragma warning restore CA1416 // Validate platform compatibility
            var cpuName = string.Empty;
            var architecture = Architecture.x86;
            foreach (ManagementObject mo in managementObjects)
            {
                cpuName = mo["Name"].ToString();
                architecture = (Architecture)((ushort)mo["Architecture"]);
            }
            WriteObject(
                  new CompatibilityReport()
                  {
                      TPM = await Sources.Windows.TPM.GetTPM(),
                      UEFI = await Sources.Windows.UEFI.GetUEFI(),
					  CPU = await Sources.Windows.CPU.GetCPU(),
                      ProcessorName = cpuName,
                      Is64Bit = architecture == Architecture.x64,
                      EnoughRAM = false,
                      RAMAmount = 0
                  }); ;
        }
    }
}
