import { HttpClientModule } from '@angular/common/http'
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { ProductApiService } from './services/product-api.service';
import { HeaderComponent } from './header/header.component';
import { ProductDetailsComponent } from './products/product-details/product-details.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductItemComponent } from './products/product-list/product-item/product-item.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { UserApiService } from './services/user-api.service';
import { ReviewListComponent } from './products/product-details/review-list/review-list.component';
import { ReviewItemComponent } from './products/product-details/review-list/review-item/review-item.component';
import { ReviewPostComponent } from './products/product-details/review-post/review-post.component';
import { ReviewApiService } from './services/review-api.service';
import { RegisterUserComponent } from './user/register-user/register-user.component';
import { LoginUserComponent } from './user/login-user/login-user.component';
import { ManagerPanelComponent } from './manager-panel/manager-panel.component';
import { ManagementListComponent } from './manager-panel/management-list/management-list.component';
import { ManagementItemComponent } from './manager-panel/management-list/management-item/management-item.component';
import { ManagementDetailsComponent } from './manager-panel/management-details/management-details.component';
import { ProductAddComponent } from './manager-panel/product-add/product-add.component';
import { TestComponent } from './test/test.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    HeaderComponent,
    ProductDetailsComponent,
    ProductListComponent,
    ProductItemComponent,
    ReviewListComponent,
    ReviewItemComponent,
    ReviewPostComponent,
    RegisterUserComponent,
    LoginUserComponent,
    ManagerPanelComponent,
    ManagementListComponent,
    ManagementItemComponent,
    ManagementDetailsComponent,
    ProductAddComponent,
    TestComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    ProductApiService,
    UserApiService,
    ReviewApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
