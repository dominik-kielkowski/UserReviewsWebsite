import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagementDetailsComponent } from './manager-panel/management-details/management-details.component';
import { ManagerPanelComponent } from './manager-panel/manager-panel.component';
import { ProductDetailsComponent } from './products/product-details/product-details.component';
import { ProductsComponent } from './products/products.component';
import { LoginUserComponent } from './user/login-user/login-user.component';
import { RegisterUserComponent } from './user/register-user/register-user.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: ProductsComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: 'login', component: LoginUserComponent },
  { path: 'register', component: RegisterUserComponent },
  { path: 'manage', component: ManagerPanelComponent, children: [
  { path: ':id', component: ManagementDetailsComponent}
  ] },
]

@NgModule({
  declarations: [],
  imports: [
    [RouterModule.forRoot(routes)]
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
