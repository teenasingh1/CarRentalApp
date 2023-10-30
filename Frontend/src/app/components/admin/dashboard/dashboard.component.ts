import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UpdateAgreementRequest } from 'src/app/models/request/update-agreement-request.model';
import { GetAgreementResponse } from 'src/app/models/response/get-agreement-response.model';
import { AgreementService } from 'src/app/services/admin/agreement.service';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  agreementList:GetAgreementResponse[]=[];
  hasReturnRequest:boolean = false;
  constructor(private agreementService:AgreementService){}
  ngOnInit(): void {
    this.agreementService.getAllAgreements().subscribe({
      next: (response)=>{
        this.agreementList= response;
        
        this.agreementList.forEach( b=>{
          if(b.agreementStatus==1) this.hasReturnRequest=true;
          b.startDate= new Date(b.startDate).toLocaleDateString("en-GB");
          b.endDate= new Date(b.endDate).toLocaleDateString("en-GB");
        })
      }
    });
  }
  
  handleDelete(id:string){
    // console.log("Deleting!!!!");
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: ' deleted !'
    }).then((result) => {
      if (result.isConfirmed) {
        this.agreementService.removeAgreement(id).subscribe({
          next:(response)=>{
            Swal.fire(
              'Deleted!',
              'Your file has been deleted.',
              'success'
            ).then(()=>{
              location.reload();
            })
          },
          error:(err)=>{
            console.log(err);        
          }
        })  
      }
    })
  }
  
  handleReturnRequest(agreement:GetAgreementResponse){
    agreement
    const request={
      agreementStatus:"Closed"
    }
    this.agreementService.handleReturnRequest(request,agreement.id).subscribe({
      next:(response)=>{
        Swal.fire({
          position: 'center',
          icon: 'success',
          title: 'Return is Approved!!',
          showConfirmButton: false,
          timer: 1500
        }).then(()=>{
          this.agreementList.find((a)=>{
            if(a.id==agreement.id){
              a.agreementStatus=3;
            }
          });
          location.reload();
        })
        // console.log(response);
        
      },
      error:(err)=>{
        console.log(err); 
      }
    });
  }
 
}
