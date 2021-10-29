import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "pets", loadChildren: () => import("./admin-pets/admin-pets.module").then(m => m.AdminPetsModule) },
  { path: "auth", loadChildren: () => import("./auth/auth.module").then(m => m.AuthModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
