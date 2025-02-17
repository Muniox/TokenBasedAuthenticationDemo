import { Component, OnInit } from '@angular/core'; 

import { Product } from '../../models/product.ts';
import { ProductService } from '../../services/product.service.js';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe((response: Product[]) => {
      this.products = response;
    });
  }


}
