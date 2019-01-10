import { ModuleWithProviders } from '@angular/core';

export interface IHardware {
  id?: number;
  assetNumber?: string;
  serialNumber?: string;
  assignedTo?: string;
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
  isAssigned?: number;
  isRetired?: number;
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
  model: IHardware;
}

export interface IGeneric {
  id?: number;
  name: string;
}

export interface IGenericResponse {
  status: boolean;
  model: IGeneric;
}

export interface IHardwareAdditionalInfo {
  id?: number;
  hardwareId?: number;
  body: string;
  createdBy: string;
  createdOn: Date;
}

export interface IHardwareAdditionalInfoResponse {
  status: boolean;
  object: IHardwareAdditionalInfo;
}
