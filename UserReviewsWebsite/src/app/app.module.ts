import { HttpClientModule } from '@angular/common/http'
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { ProductApiService } from './product-api.service';
import { HeaderComponent } from './header/header.component';
import { ProductDetailsComponent } from './products/product-details/product-details.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductItemComponent } from './products/product-list/product-item/product-item.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { UserApiService } from './user-api.service';
import { AuthenticationComponent } from './authentication/authentication.component';
import { ReviewListComponent } from './products/product-details/review-list/review-list.component';
import { ReviewItemComponent } from './products/product-details/review-list/review-item/review-item.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    HeaderComponent,
    ProductDetailsComponent,
    ProductListComponent,
    ProductItemComponent,
    AuthenticationComponent,
    ReviewListComponent,
    ReviewItemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    ProductApiService,
    UserApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
