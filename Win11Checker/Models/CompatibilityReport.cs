namespace Win11Checker.Models
{
    class CompatibilityReport
    {
        //TPM: Trusted Platform Module (TPM) version 2.0.
        public bool Tpm { get; set; } = false;
        //System firmware: UEFI, Secure Boot capable
        public bool SecureBoot { get; set; } = false;
        public bool Is64Bit { get; set; } = false;
        //Processor: 1 gigahertz (GHz) or faster with two or more cores on a compatible 64-bit processor or system on a chip (SoC).
        public bool CompatibleProcessor { get; set; } = false;
        public string ProcessorName { get; set; }
        //RAM: 4 gigabytes (GB) or greater.
        public bool EnoughRAM { get; set; } = false;
        public int RAMAmount { get; set; } = 0;
        //Storage: 64 GB* or greater available storage is required to install Windows 11.
        public bool EnoughStorage { get; set; } = false;
        public int StorageAmount { get; set; } = 0;
        //Graphics card: Compatible with DirectX 12 or later, with a WDDM 2.0 driver.
        public bool DirectX12Graphics { get; set; }
        //Display: High definition (720p) display, 9" or greater monitor, 8 bits per color channel.
        public bool CompatibleDisplay { get; set; } = false;
    }
}
