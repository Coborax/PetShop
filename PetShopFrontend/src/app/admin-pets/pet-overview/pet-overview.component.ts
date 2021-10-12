import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {PetDto} from "../../shared/pet.dto";

@Component({
  selector: 'app-pet-overview',
  templateUrl: './pet-overview.component.html',
  styleUrls: ['./pet-overview.component.scss']
})
export class PetOverviewComponent implements OnInit {

  pets: PetDto[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<PetDto[]>("https://localhost:5001/api/pets").subscribe((res) => {
      this.pets = res;
      console.log("Fetched Pets: " + JSON.stringify(this.pets));
    }, (err) => {
      console.log("Error fetching pets, Error: " + err.message);
    });
  }

}
