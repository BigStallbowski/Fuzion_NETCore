import { ModuleWithProviders } from '@angular/core';

export interface ITotalAvailableCount {
  totalAvailableHardware: number;
  totalAvailableWorkstations: number;
  totalAvailableLaptops: number;
  totalAvailableMobileDevices: number;
}

export interface ITotalDeployedCount {
  totalDeployedHardware: number;
  totalDeployedWorkstations: number;
  totalDeployedLaptops: number;
  totalDeployedMobileDevices: number;
}
