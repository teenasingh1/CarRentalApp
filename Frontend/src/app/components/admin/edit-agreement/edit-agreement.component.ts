import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UpdateAgreementRequest } from 'src/app/models/request/update-agreement-request.model';
import { GetAgreementResponse } from 'src/app/models/response/get-agreement-response.model';
import { AgreementService } from 'src/app/services/admin/agreement.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-agreement',
  templateUrl: './edit-agreement.component.html',
  styleUrls: ['./edit-agreement.component.css']
})
export class EditAgreementComponent implements OnInit{
  agreement:any;

  constructor(private agreementService:AgreementService, private route:ActivatedRoute, private router:Router){}
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(param)=>{
        const id = param.get('id');
        if(id){
          this.agreementService.getAgreement(id).subscribe({
            next:(response)=>{
              this.agreement=response;
              console.log(this.agreement);
              
              this.agreement.startDate= this.agreement.startDate.split('T')[0];
              this.agreement.endDate= this.agreement.endDate.split('T')[0];
            }
          })
        }
      }
    })
  }
  handleUpdate(){
    var startDate= new Date(this.agreement.startDate);
    var endDate= new Date(this.agreement.endDate);
    const numDays = (endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24)+1;
    const request:UpdateAgreementRequest={
      startDate:this.agreement.startDate,
      endDate:this.agreement.endDate,
      totalCost:numDays*this.agreement.car.rentalPrice
    }

    this.agreementService.updateAgreement(request,this.agreement.id).subscribe({
      next:(response)=>{
        Swal.fire({
          position: 'center',
          icon: 'success',  
          title: 'Updated Successfully',
          showConfirmButton: false,
          timer: 1500
        }).then(()=>{
          this.router.navigateByUrl('/admin')
        })
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }

}
