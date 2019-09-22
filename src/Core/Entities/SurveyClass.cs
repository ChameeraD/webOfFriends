using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class SurveyClass : BaseEntity
    {
        public Guid SchoolClassId { get; set; }
        public Guid SurveryId { get; set; }    
        public virtual SchoolClass SchoolClass { get; set; } 
        public virtual Survey Survey { get; set; }       
        public virtual ICollection<SurveyRecord> SurveyRecords { get; set; }
    }
}
