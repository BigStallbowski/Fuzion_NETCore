namespace Fuzion.UI.Persistence.DTOS
{
    public class HardwareCounts
    {
        public int TotalAvailableHardware { get; set; }
        public int TotalDeployedHardware { get; set; }

        public int TotalAvailableWorkstations { get; set; }
        public int TotalDeployedWorkstations { get; set; }

        public int TotalAvailableLaptops { get; set; }
        public int TotalDeployedLaptops { get; set; }

        public int TotalAvailableMobileDevices { get; set; }
        public int TotalDeployedMobileDevices { get; set; }
    }
}