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
					  TPM = await Sources.Windows.TPM.GetTPM(),
					  UEFI = await Sources.Windows.UEFI.GetUEFI(),
					  CPU = await Sources.Windows.CPU.GetCPU(),
					  RAM = await Sources.Windows.RAM.GetRAMAsync(),
				  }); ;
		}
	}
}
