import { RouteInfo } from './sidebar.metadata';

// Sidebar menu Routes and data
export const ROUTES: RouteInfo[] = [

  {
    path: '', title: 'Dashboard', icon: 'icon-home', class: '', badge: '', badgeClass: '', isExternalLink: false,
    submenu: []
  },
  {
    path: '/hardware', title: 'Assign Device', icon: 'ft-user-plus', class: '', badge: '2', badgeClass: '', isExternalLink: false,
    submenu: []
  },
  {
    path: '/hardware/add', title: 'Add Device', icon: 'ft-plus', class: '', badge: '2', badgeClass: '', isExternalLink: false,
    submenu: []
  },
  {
    path: '', title: 'Workstations', icon: 'fa fa-desktop', class: 'has-sub', badge: '', badgeClass: '', isExternalLink: false,
    submenu: [
      { path: '/workstations/assigned', title: 'Assigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/workstations/unassigned', title: 'Unassigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/workstations/retired', title: 'Retired', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] }
    ]
  },
  {
    path: '', title: 'Laptops', icon: 'fa fa-laptop', class: 'has-sub', badge: '', badgeClass: '', isExternalLink: false,
    submenu: [
      { path: '/laptops/assigned', title: 'Assigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/laptops/unassigned', title: 'Unassigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/laptops/retired', title: 'Retired', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] }
    ]
  },
  {
    path: '', title: 'Mobile', icon: 'fa fa-tablet', class: 'has-sub', badge: '', badgeClass: '', isExternalLink: false,
    submenu: [
      { path: '/mobile/assigned', title: 'Assigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/mobile/unassigned', title: 'Unassigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/mobile/retired', title: 'Retired', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] }
    ]
  },
  {
    path: '', title: 'Administration', icon: 'fa fa-cog', class: 'has-sub', badge: '', badgeClass: '', isExternalLink: false,
    submenu: [
      { path: '/administration/hardwaretypes', title: 'Hardware Types', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/administration/manufacturers', title: 'Manufacturers', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/administration/models', title: 'Models', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/administration/operatingsystems', title: 'Operating Systems', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/administration/purposes', title: 'Purposes', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/administration/settings', title: 'Settings', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] }
    ]
  }
];
