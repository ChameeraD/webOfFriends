using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class SurveyRecord : BaseEntity
    {
        public Guid SurveyClassId { get; set; }
        public Guid StudentId { get; set; }       
        public virtual SurveyClass SurveyClass { get; set; }      
        public virtual Student Student { get; set; }
        public virtual ICollection<BestFriend> BestFriends { get; set; }
    }
}
