import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PetOverviewComponent} from "./pet-overview/pet-overview.component";

const routes: Routes = [
  { path: "", component: PetOverviewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminPetsRoutingModule { }
