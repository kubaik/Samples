import {Component, OnInit} from '@angular/core';
import {Product} from '../../models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  name = 'Angular';

  products = Product.all;

  constructor() {
  }

  ngOnInit() {
  }

  share(product: Product) {
    alert(`Share: Produto: ${product.id} - ${product.name}`);
  }
}
