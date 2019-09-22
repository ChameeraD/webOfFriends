import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SurveyRoutingModule } from "./survey-routing.module";
import { SurveyComponent } from "./survey/survey.component";

@NgModule({
  imports: [CommonModule, SurveyRoutingModule],
  declarations: [
    // SurveyComponent
  ]
})
export class SurveyModule {}
