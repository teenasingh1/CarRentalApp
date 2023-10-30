import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UpdateAgreementRequest } from 'src/app/models/request/update-agreement-request.model';
import { GetAgreementResponse } from 'src/app/models/response/get-agreement-response.model';
import { AgreementService } from 'src/app/services/admin/agreement.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-bookings',
  templateUrl: './user-bookings.component.html',
  styleUrls: ['./user-bookings.component.css']
})
export class UserBookingsComponent implements OnInit{
  bookingsList: GetAgreementResponse[]=[];
  
  constructor(private agreementService: AgreementService,private router:Router){}
  ngOnInit(): void {
    this.agreementService.getUserAgreements().subscribe({
      next:(response)=>{
        this.bookingsList=response;
        this.bookingsList.forEach((b)=>{
          console.log(b.startDate, b.endDate);
          b.startDate= new Date(b.startDate).toLocaleDateString("en-GB");
          b.endDate= new Date(b.endDate).toLocaleDateString("en-GB");
        })
  
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }

  //handles return request
  requestForReturn(booking:GetAgreementResponse){
    var request = {
      agreementStatus:"ReturnRequested"
    }
    this.agreementService.handleReturnRequest(request,booking.id).subscribe({
      next:(response)=>{
        console.log(response);  
        Swal.fire({
          position: 'center',
          icon: 'success',  
          title: 'Booking Sucessfully',
          showConfirmButton: false,
          timer: 1500
        }).then(()=>{
          this.bookingsList.find((b)=>{
            if(b.id==booking.id){
              booking.agreementStatus=1;
            }
          })
        })
      },
      error:(err)=>{
        console.log(err); 
      }
    })
  }
}
