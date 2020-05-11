import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  readonly data = [
    {id: 1, name: 'Fábio Naspolini', cidade: 'São José dos Pinhais'},
    {id: 3, name: 'Teste Fabio', cidade: 'Curitiba'},
    {id: 2, name: 'Fábio 2', cidade: 'Criciúma'},
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
