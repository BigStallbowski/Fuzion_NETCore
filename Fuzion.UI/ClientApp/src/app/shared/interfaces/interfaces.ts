import { ModuleWithProviders } from '@angular/core';

export interface IHardware {
  id?: number;
  assetNumber: string;
  serialNumber: string;
  assignedTo: string;
  hardwareType?: number;
  hardwareTypeId?: number;
  manufacturer?: number;
  manufacturerId?: number;
  model?: number;
  modelId?: number;
  operatingSystem?: string;
  osId?: number;
  purpose?: number;
  purposeId?: number;
  isAssigned: number;
  isRetired: number;
}

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

export interface IHardwareResponse {
  status: boolean;
  hardware: IHardware;
}

export interface IList {
  id?: number;
  name: string;
}



