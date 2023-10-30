import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/user/car.service';
import { GetCarResponse } from 'src/app/models/response/get-car-response.model';
import { Model } from 'src/app/models/response/model.model';
import { Maker } from 'src/app/models/response/maker.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'] 
})
export class HomeComponent implements OnInit {
  //declare properties to store lists of car details
  carList: GetCarResponse[]=[];
  modelList: Model[]=[];
  makerList: Maker[]=[];
  
  // declare properties for the selected car mode
  modelSelected:number =-1;
  makerSelected:number = -1;
  rentalPrice:number= -1;

  constructor(private carService: CarService) { }
  ngOnInit(): void {
    //get all models
    this.carService.getAllModels().subscribe({
      next:(response)=>{
        this.modelList=response;
      },
      error:(err)=>{
        console.log(err); 
      }
    });

    //get all makers
    this.carService.getAllMakers().subscribe({
      next:(response)=>{
        this.makerList=response;
      },
      error:(err)=>{
        console.log(err); 
      }
    });

    this.carService.getAllCars().subscribe({
      next:(response)=>{
        this.carList = response;
        console.log(this.carList);
      },
      error: (err)=>{
        console.log(err);
      }
    })
  }
  //handle Filters Applied
  handleSearch(){
    console.log(this.makerSelected, this.modelSelected, this.rentalPrice);
    this.carService.getAllCars(this.makerSelected, this.modelSelected,this.rentalPrice).subscribe({
      next:(response)=>{
        this.carList=response;
        console.log(this.carList);
        
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
  //Removing search Filter
  removeSearchFilter(){
    
    location.reload();
  }

}
