import {Component, OnInit} from '@angular/core';
import {Product} from '../../product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  name = 'Angular';

  products = [
    new Product(1, 'Banana', 'banana'),
    new Product(2, 'Maça', 'maça'),
    new Product(3, 'Laranja', 'laranja'),
    new Product(3, 'Uva', 'uva'),
    new Product(3, 'Jabuticaba', '')
  ];

  constructor() {
  }

  ngOnInit() {
  }
}
