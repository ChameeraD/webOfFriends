using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class BestFriend : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid SurveyRecordId { get; set; }
        public virtual Student Student { get; set; } 
        public virtual SurveyRecord SurveyRecord { get; set; }

    }
}
