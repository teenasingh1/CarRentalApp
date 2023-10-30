import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/user/home/home.component';
import { LoginComponent } from './components/global/login/login.component';
import { CarDetailsComponent } from './components/user/car-details/car-details.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { EditAgreementComponent } from './components/admin/edit-agreement/edit-agreement.component';
import { UserBookingsComponent } from './components/user/user-bookings/user-bookings.component';


const routes: Routes =[
  {path:'',redirectTo:'user',pathMatch:'full'}, 
  {
    path:'login',
    component:LoginComponent
  },
  
  {  
    path:'user',
    component:HomeComponent,
  },
  {
    path:'user/booking/:id',
    component:CarDetailsComponent
  },
  {
    path:'user/bookings',
    component:UserBookingsComponent
  },
  {
    path:'admin',
    component:DashboardComponent,
  },
  {
    path:'admin/edit/:id',
    component:EditAgreementComponent
  }
]


@NgModule({
  exports: [RouterModule],
  imports: [
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
