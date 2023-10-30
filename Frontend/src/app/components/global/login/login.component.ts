import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserAuthService } from 'src/app/services/global/user-auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //used to store the user's login form data
    formModel:any;
  //constructor injects the UserAuthService, FormBuilder, and Router services
    constructor(private authService: UserAuthService, private fb:FormBuilder, private router:Router) {
     //creates a new FormGroup using the FormBuilder service
      this.formModel=this.fb.group({
        Email:['',Validators.compose([Validators.required,Validators.email])],
        Password:['',Validators.compose([Validators.required,Validators.nullValidator])]
      })
    }

    ngOnInit(): void {
      
      if(localStorage.getItem('token')!=null){
      }
    }
    onSubmit(){
      this.authService.login(this.formModel.value).subscribe({
        next:(response:any)=>{
          localStorage.setItem('token',response.token);
          if(this.authService.roleMatch(["Admin"])){
            this.router.navigateByUrl('/admin')
          }
          else{
            this.router.navigateByUrl('/user');
          }
        },
        error:(err)=>{console.log(err);}
      });
      
    }
}
