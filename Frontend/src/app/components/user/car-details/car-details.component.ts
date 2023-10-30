import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateAgreementRequest } from 'src/app/models/request/create-agreement-request.model';
import { GetCarResponse } from 'src/app/models/response/get-car-response.model';
import { AgreementService } from 'src/app/services/admin/agreement.service';
import { CarService } from 'src/app/services/user/car.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit{

  isLogin: boolean = false;
  //initializes a carDetails object with default values
  carDetails: GetCarResponse ={
    id:'',
    name:'',
    maker:{
        id:0,
        makerName:'',
    },
    makerId:0,
    modelId:0,
    model:{
        id:0,
        modelName:'',
    },
    rentalPrice:0,
    carImage:'',
    agreementStatus: 1
  }
  
  startDate:Date= new Date();
  endDate:Date= new Date();

 //CarService and AgreementService are services used to make HTTP requests to your API
  constructor(private route: ActivatedRoute, private router: Router, private carService: CarService, private agreementService: AgreementService){}

  ngOnInit(): void {
    if(localStorage.getItem('token')!=null){
      this.isLogin=true;
    }
    //uses the ActivatedRoute to subscribe to route parameter changes
    this.route.paramMap.subscribe({
      next: (param)=>{
        const id =param.get('id');
        console.log(id);
        if(id){
          this.carService.getCar(id)
          .subscribe({
            next: (response)=>{
              this.carDetails=response;
              console.log(this.carDetails); 
            },
            error: (err)=>{
                console.log(err);
            }
          })
        }
      }
    })
  }


  //function to handle Bookings

  handleBooking(){
    var startDate= new Date(this.startDate);
    var endDate= new Date(this.endDate);
    const numDays = (endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24)+1;

    var request:CreateAgreementRequest = {
      carId:this.carDetails.id,
      startDate: startDate,
      endDate:endDate,
      totalCost:numDays*this.carDetails.rentalPrice,
      
    }
    
    //makes an HTTP POST request to the addAgreement
    this.agreementService.addAgreement(request).subscribe({
      next:(response)=>{
        // console.log(response); 
        Swal.fire({
          position: 'center',
          icon: 'success',
          title: 'Booking Sucessfully',
          showConfirmButton: false,
          timer: 1500
        })
      },
      error:(err)=>{
        console.log(err);
        
      }
    })

  }
}
