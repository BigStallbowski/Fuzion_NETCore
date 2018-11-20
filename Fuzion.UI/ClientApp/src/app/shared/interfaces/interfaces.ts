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

export interface IHardware {
  id?: number,
  assetNumber: string,
  serialNumber: string,
  assignedTo: string,
  hardwareTypeId: number,
  manufacturerId: number,
  modelId: number,
  osId: number,
  purposeId: number;
  isAssigned: number,
  isRetired: number
}

export interface IHardwareList {
  id: number,
  assetNumber: string
}


