import { SurveyComponent } from './survey/survey/survey.component';

import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes }  from '@angular/router';


const applicationRoutes:Routes = [
  {path:'survey/:payloadid/:token', component: SurveyComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(applicationRoutes)
  ],
  exports: [
    RouterModule
  ],
  providers: [],
})
export class AppRoutingModule { }
