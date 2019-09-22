import { SurveyRecord } from './../../services/survey/surveyRecord.model';
import { Class } from './../../services/survey/class.model';
import { Component, OnInit, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { PageScrollService } from 'ngx-page-scroll-core';
import { SurveyService } from './../../services/survey/survey.service';
import { Student } from './../../services/survey/student.model';
import {ActivatedRoute, Router, ParamMap} from '@angular/router';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css'],
  providers: [SurveyService, Student, SurveyRecord,Class]
})

export class SurveyComponent implements OnInit {
  showSecond = false;
  showThird = false;
  selectedFriendsList = [];
  selectedFriendBtnClass = 'selectedFriendBtn';
  /*listOfFriends = ['Ben', 'Rosa', 'Fin', 'Lily',
  'Jess', 'Heidi', 'Ryan', 'Nya', 'Poppy', 'Joan', 'Tom', 'Lauren',
   'Brien', 'Olly', 'Falcon', 'S-J', 'Sam', 'Lewis', 'Neve', 'Anna',
    'Elray', 'Fabio', 'Luke', 'Shep', 'Olivia', 'Lucy', 'Lucas', 'Evie', 'Chris', 'Jake'];*/

  constructor(public student: Student,
    public surveyRecord: SurveyRecord,
    public surveyService: SurveyService,
    private pageScrollService: PageScrollService,
    private route:ActivatedRoute,
    private router:Router,
    
    @Inject(DOCUMENT) private document: any) { }

    classId : any;
    studentId:any;
    classSurveyId:any;
    student1:Student;
    class:Class;
  ngOnInit() {
    this.refreshStudentList();
    this.route.paramMap.subscribe(
      prams=>{
        this.classId = prams.get('classId');
        this.studentId = prams.get('studentId');
        this.classSurveyId = prams.get('classSurveyId');
      }
    );
    console.log(this.classId,this.studentId,this.classSurveyId);
    this.getStudentDetails(this.studentId);
    this.getClassDetails(this.classId);
  }

  refreshStudentList() {
    this.surveyService.getStudents().subscribe((res) => {
      this.surveyService.student = res as Student[];
    });
  }

  getStudentDetails(_id:number){
    console.log(_id);
      this.surveyService.getStudent(_id).subscribe((res:any)=>{
        this.student1=res;
      });
      
  }
  getClassDetails(_id:number){
    this.surveyService.getClass(_id).subscribe((res:any)=>{
      this.class=res;
    });

}


  // handle friend selection
  selectFriend(event: MouseEvent, friendIndex: number) {
    console.log('TCL: SurveyComponent -> selectFriend -> event , friendIndex', event, friendIndex);

    const selectedFriendName = this.surveyService.student[friendIndex - 1];

    if (this.selectedFriendsList.includes(selectedFriendName)) {

      /**
       * We will change selected color ro unselected
       * Remove from list of friends
       */

      (event.target as HTMLElement).classList.remove(this.selectedFriendBtnClass);
      const listIndex = this.selectedFriendsList.indexOf(selectedFriendName);
      this.selectedFriendsList.splice(listIndex, 1);
      // const
    } else {

      /**
       * Change button color to selected
       * Add to the listoffriends
       */
      if (this.selectedFriendsList.length < 3) {
        (event.target as HTMLElement).classList.add(this.selectedFriendBtnClass);
        this.selectedFriendsList.push(selectedFriendName);
      } else {
        alert('You can only select three friends');
      }
    }
    console.log(this.selectedFriendsList);
  }

  thirdPannel() {
    this.showThird = true;
    setTimeout(() => {
      this.scrollToTarget('#survey');
    }, 100);

    // '#survey'
    let record = new SurveyRecord;
    record = {
      SurveyClassId: this.classSurveyId,
      StudentId: this.studentId,
      BestFriends: [
        {
          StudentId: this.selectedFriendsList[0].id,
          Created: new Date(),
          LastUpdated: new Date(),
        },
        {
          StudentId: this.selectedFriendsList[1].id,
          Created: new Date(),
          LastUpdated: new Date(),
        },
        {
          StudentId: this.selectedFriendsList[2].id,
          Created: new Date(),
          LastUpdated: new Date(),
        }
      ],
      Created: new Date(),
      LastUpdated: new Date(),
    };
    console.log(record);
    this.surveyService.postSurveyRecord(record).subscribe((res: any) => {
      if (res.state == false) {
        alert(res.msg);
      } else {
        alert('Record Added');
      }
    });
  }

  scrollToTarget(target: string) {
    this.pageScrollService.scroll({
      document: this.document,
      scrollTarget: target,
    });
  }


}


