import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AgreementService } from 'src/app/services/admin/agreement.service';
import { UserAuthService } from 'src/app/services/global/user-auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLogin:boolean =false;
  isAdmin:boolean =false;
  numberOfAgreementsUserHas:number=0;
  constructor(private authService:UserAuthService, private router:Router, private agreementService:AgreementService){
    var token =localStorage.getItem('token');
    if(token!=null){
      this.isLogin=true;
      this.isAdmin=this.authService.roleMatch(['Admin'])
    }
  }

  ngOnInit(): void {
    // calls the getUserAgreements() method on the AgreementService
    this.agreementService.getUserAgreements().subscribe({
      next:(response)=>{
        this.numberOfAgreementsUserHas= response.length;
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
  
  Logout(){
    localStorage.removeItem('token');
    this.router.navigateByUrl('/login');
  }
  
}
