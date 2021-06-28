namespace Win11Checker.Models
{
	class CompatibilityReport
	{
		//TPM: Trusted Platform Module (TPM) version 2.0.
		public TPM TPM { get; set; }
		//System firmware: UEFI, Secure Boot capable
		public UEFI UEFI { get; set; }
		//Processor: 1 gigahertz (GHz) or faster with two or more cores on a compatible 64-bit processor or system on a chip (SoC).
		public CPU CPU { get; set; }
		//RAM: 4 gigabytes (GB) or greater.
		public RAM RAM { get; set; }
		//Storage: 64 GB* or greater available storage is required to install Windows 11.
		public bool EnoughStorage { get; set; } = false;
		public int StorageAmount { get; set; } = 0;
		//Graphics card: Compatible with DirectX 12 or later, with a WDDM 2.0 driver.
		public bool DirectX12Graphics { get; set; }
		//Display: High definition (720p) display, 9" or greater monitor, 8 bits per color channel.
		public bool CompatibleDisplay { get; set; } = false;
	}
}
