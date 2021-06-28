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
        protected override void ProcessRecord()
        {
            var runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();
            var pipeline = runSpace.CreatePipeline();
            var tpmCmd = new Command("Get-TPM");
            pipeline.Commands.Add(tpmCmd);
            var tpmOutput = pipeline.Invoke();

            pipeline = runSpace.CreatePipeline();
            var SecureBootCmd = new Command("Confirm-SecureBootUEFI");
            pipeline.Commands.Add(SecureBootCmd);
            var SbOutput = pipeline.Invoke();

#pragma warning disable CA1416 // Validate platform compatibility
            SelectQuery selectQuery = new("Win32_Processor");
#pragma warning restore CA1416 // Validate platform compatibility
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(selectQuery);
            ManagementObjectCollection managementObjects = managementObjectSearcher.Get();
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
                      Tpm = bool.Parse(tpmOutput.First().Properties["TpmPresent"].Value.ToString()),
                      SecureBoot = bool.Parse(SbOutput.First().ToString()),
                      ProcessorName = cpuName,
                      Is64Bit = architecture == Architecture.x64,
                      EnoughRAM = false,
                      RAMAmount = 0
                  }); ;
        }
    }
}
