import { RouteInfo } from './sidebar.metadata';

// Sidebar menu Routes and data
export const ROUTES: RouteInfo[] = [

  {
    path: '', title: 'Dashboard', icon: 'icon-home', class: '', badge: '2', badgeClass: 'badge badge-pill badge-danger mt-1', isExternalLink: false,
    submenu: []
  },
  {
    path: '/assign', title: 'Assign Device', icon: 'ft-user-plus', class: '', badge: '2', badgeClass: 'badge badge-pill badge-danger mt-1', isExternalLink: false,
    submenu: []
  },
  {
    path: '/adddevice', title: 'Add Device', icon: 'ft-plus', class: '', badge: '2', badgeClass: 'badge badge-pill badge-danger mt-1', isExternalLink: false,
    submenu: []
  },
  {
    path: '', title: 'Workstations', icon: 'fa fa-desktop', class: 'has-sub', badge: '', badgeClass: '', isExternalLink: false,
    submenu: [

      { path: '/assigndworkstations', title: 'Assigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/unassignedworkstations', title: 'Unassigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/retiredworkstations', title: 'Retired', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] }   
    ]
  },
  {
    path: '', title: 'Laptops', icon: 'fa fa-laptop', class: 'has-sub', badge: '', badgeClass: '', isExternalLink: false,
    submenu: [

      { path: '/assignedlaptops', title: 'Assigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/unassignedlaptops', title: 'Unassigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/retiredlaptops', title: 'Retired', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] }
    ]
  },
  {
    path: '', title: 'Mobile', icon: 'fa fa-tablet', class: 'has-sub', badge: '', badgeClass: '', isExternalLink: false,
    submenu: [

      { path: '/assignedmobile', title: 'Assigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/unassignedmobile', title: 'Unassigned', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      { path: '/retiredmobile', title: 'Retired', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] }
    ]
  }
];
