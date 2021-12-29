import { Component } from '@angular/core';
import { ProductService } from '@api';
import { combine } from '@core';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  readonly vm$ = combine(this._productService.get())
  .pipe(
    map(([products]) => {
      return {
        products,
        loading: products == undefined
      }
    })
  )

  constructor(
    private readonly _productService: ProductService
  ) {

  }
}
