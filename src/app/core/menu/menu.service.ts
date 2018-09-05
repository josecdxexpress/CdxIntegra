import { Injectable } from '@angular/core';

export interface BadgeItem {
  type: string;
  value: string;
}

export interface ChildrenItems {
  state: string;
  name: string;
  type?: string;
}

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
  badge?: BadgeItem[];
  children?: ChildrenItems[];
}

const MENUITEMS = [
  {
    state: '/',
    name: 'HOME',
    type: 'link',
    icon: 'explore'
  },
  // {
  //   state: 'http://primer.nyasha.me/docs',
  //   name: 'DOCS',
  //   type: 'extTabLink',
  //   icon: 'local_library'
  // },
  {
    state: 'usuarios',
    name: 'Usuários',
    type: 'link',
    icon: 'explore'
  },
  {
    state: 'parametros',
    name: 'Parametros',
    type: 'link',
    icon: 'explore'
  },
  {
    state: 'requisicoes',
    name: 'Requisições',
    type: 'link',
    icon: 'explore'
  },
];

@Injectable()
export class MenuService {
  getAll(): Menu[] {
    return MENUITEMS;
  }

  add(menu) {
    MENUITEMS.push(menu);
  }
}
