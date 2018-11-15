import { ModuleWithProviders } from '@angular/core';

export interface IHardwareCounts {
  totalAvailableHardware: number;
  totalDeployedHardware: number;
  totalDeployedHardwarePercentage?: number;
  totalAvailableWorkstations: number;
  totalDeployedWorkstations: number;
  totalDeployedWorkstationPercentage?: number;
  totalAvailableLaptops: number;
  totalDeployedLaptops: number;
  totalDeployedLaptopPercentage?: number;
  totalAvailableMobileDevices: number;
  totalDeployedMobileDevices: number;
  totalDeployedMobileDevicePercentage?: number;
}


