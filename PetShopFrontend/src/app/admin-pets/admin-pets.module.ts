import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminPetsRoutingModule } from './admin-pets-routing.module';
import { PetOverviewComponent } from './pet-overview/pet-overview.component';


@NgModule({
  declarations: [
    PetOverviewComponent
  ],
  imports: [
    CommonModule,
    AdminPetsRoutingModule
  ]
})
export class AdminPetsModule { }
