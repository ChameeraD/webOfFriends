export class SurveyRecord {
        SurveyClassId: Number;
        StudentId: Number;
        BestFriends: [
          {
            StudentId: Number;
            Created: Date;
            LastUpdated: Date;
          },
          {
            StudentId: Number;
            Created: Date;
            LastUpdated: Date;
          },
          {
            StudentId: Number;
            Created: Date;
            LastUpdated: Date;
          }
        ];
        Created: Date;
        LastUpdated: Date;
}
