using System.Management.Automation;
using Win11Checker.Models;

namespace Win11Checker
{
	[Cmdlet(VerbsCommon.Get, "Win11Compatibility")]
	[OutputType(typeof(CompatibilityReport))]
	public class Win11Checker : Cmdlet
	{
		protected override async void ProcessRecord()
		{
			WriteObject(
				new CompatibilityReport()
				{
					TPM = await Sources.Windows.TPM.GetTPMAsync(),
					UEFI = await Sources.Windows.UEFI.GetUEFIAsync(),
					CPU = await Sources.Windows.CPU.GetCPUAsync(),
					RAM = await Sources.Windows.RAM.GetRAMAsync(),
					Storage = await Sources.Windows.Storage.GetStorageAsync()
				});
		}
	}
}
