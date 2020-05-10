import { Component } from '@angular/core';

import { PoMenuItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  readonly menus: Array<PoMenuItem> = [
    { label: 'Início', action: this.onClick.bind(this), icon: 'po-icon-home', shortLabel: 'Início' },
    { label: 'Cadastro de Usuários', action: this.onClick.bind(this), icon: 'po-icon-users', shortLabel: 'Usuários'}
  ];

  readonly data = [
    {id: 1, name: 'Fábio Naspolini', cidade: 'São José dos Pinhais'},
    {id: 3, name: 'Fábio Naspolini', cidade: 'Curitiba'},
    {id: 2, name: 'Fábio Naspolini', cidade: 'Criciúma'},
  ];

  private onClick() {
    alert('Clicked in menu item')
  }
}
