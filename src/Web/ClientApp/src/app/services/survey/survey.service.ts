import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Student } from './student.model';
import { SurveyRecord } from './surveyRecord.model';


@Injectable({
  providedIn: 'root'
})
export class SurveyService {
  readonly baseURL1 = 'https://localhost:5001/api/Student';
  readonly baseURL2 = 'https://localhost:5001/api/SurveyRecord';
  readonly baseURL3 = 'https://localhost:5001/api/SchoolClass';

  student: Student[];
  surveyRecord: SurveyRecord[];
  constructor(private http: HttpClient) { }

  getStudents() {
    return this.http.get(this.baseURL1);
  }

  getStudent(_id: number) {
    return this.http.get(this.baseURL1 +'/'+_id);
  }

  getClass(_id: number) {
    return this.http.get(this.baseURL3 +'/'+_id);
  }


  postSurveyRecord(surveyRecord:SurveyRecord) {
    console.log(surveyRecord);
    return this.http.post(this.baseURL2,surveyRecord);
  }

}
